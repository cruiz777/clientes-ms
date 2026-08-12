using clientes_ms.Application.Records.Response;
using Microsoft.EntityFrameworkCore;
using MediatR;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using clientes_ms.Application.Queries.Clientes;

namespace clientes_ms.Application.Handlers.Cliente
{
    public class GetClientesPagedHandler
        : IRequestHandler<GetClientesPaged, ApiResponse<IEnumerable<ClientesExploradorResponse>>>
    {
        private readonly IBaseRepository<Clientes> _repository;
        private readonly IBaseRepository<ClienteDatosAdicionales> _clienteDatosAdicionalesRepository;

        private const int MaxPageSize = 40000;

        public GetClientesPagedHandler(
            IBaseRepository<Clientes> repository,
            IBaseRepository<ClienteDatosAdicionales> clienteDatosAdicionalesRepository)
        {
            _repository = repository;
            _clienteDatosAdicionalesRepository = clienteDatosAdicionalesRepository;
        }

        public async Task<ApiResponse<IEnumerable<ClientesExploradorResponse>>> Handle(
            GetClientesPaged request,
            CancellationToken cancellationToken)
        {
            try
            {
                var pageNumber = request.PageNumber <= 0
                    ? 1
                    : request.PageNumber;

                var pageSize = request.PageSize <= 0
                    ? 10
                    : Math.Min(request.PageSize, MaxPageSize);

                var baseQuery = _repository
                    .AsQueryable()
                    .AsNoTracking();

                if (!string.IsNullOrWhiteSpace(request.BusquedaGeneral))
                {
                    var filtro = request.BusquedaGeneral
                        .Trim()
                        .ToLower();

                    baseQuery = baseQuery.Where(e =>
                        (!string.IsNullOrEmpty(e.Nomcli) &&
                         e.Nomcli.ToLower().Contains(filtro)) ||

                        (!string.IsNullOrEmpty(e.Ruc) &&
                         e.Ruc.ToLower().Contains(filtro)) ||

                        e.ClientesCodigo.ToString().Contains(filtro)
                    );
                }

                if (!string.IsNullOrWhiteSpace(request.PrefijoBusqueda))
                {
                    var prefijo = request.PrefijoBusqueda.Trim();

                    baseQuery = baseQuery.Where(e =>
                        e.Prefijos.Any(p => p.Codpre == prefijo));
                }

                var totalRegistros = await baseQuery
                    .CountAsync(cancellationToken);

                var clientesPagina = await baseQuery
                    .OrderByDescending(e => e.Fecing)
                    .ThenBy(e => e.ClientesCodigo)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(e => new
                    {
                        e.ClientesCodigo,
                        e.Nomcli,
                        e.Ruc,
                        e.Dircli,
                        e.Fecing,
                        e.Representante,
                        e.Telefono,

                        ZonaReferencia = e.IdZonaNavigation != null
                            ? e.IdZonaNavigation.Referencia
                            : string.Empty,

                        EstadoNombre = e.IdEstadoEmpresaNavigation != null
                            ? e.IdEstadoEmpresaNavigation.Nombre
                            : string.Empty,

                        TipoCliente = e.IdTipoClienteNavigation != null
                            ? e.IdTipoClienteNavigation.Descripcion
                            : string.Empty,

                        GrupoEmpresa = e.IdGrupoEmpresa != null &&
                                       e.IdGrupoEmpresaNavigation != null
                            ? e.IdGrupoEmpresaNavigation.Codigo
                            : string.Empty,

                        Prefijo = e.Prefijos != null && e.Prefijos.Any()
                            ? string.Join("/", e.Prefijos.Select(p => p.Codpre))
                            : string.Empty,

                        NPrefijo = e.Prefijos.Count()
                    })
                    .ToListAsync(cancellationToken);

                var codigosClientes = clientesPagina
                    .Select(x => Convert.ToInt64(x.ClientesCodigo))
                    .Distinct()
                    .ToList();

                var adicionalesDb = await _clienteDatosAdicionalesRepository
                    .AsQueryable()
                    .AsNoTracking()
                    .Where(x =>
                        x.ClientesCodigo.HasValue &&
                        codigosClientes.Contains(x.ClientesCodigo.Value))
                    .ToListAsync(cancellationToken);

                var adicionalesPorCliente = adicionalesDb
                    .Where(x => x.ClientesCodigo.HasValue)
                    .GroupBy(x => x.ClientesCodigo!.Value)
                    .ToDictionary(
                        g => g.Key,
                        g => g.First());

                var data = clientesPagina
                    .Select(e =>
                    {
                        var clienteCodigo = Convert.ToInt64(e.ClientesCodigo);

                        adicionalesPorCliente.TryGetValue(
                            clienteCodigo,
                            out var adicional);

                        return new ClientesExploradorResponse
                        {
                            ClientesCodigo = clienteCodigo,
                            NomCli = e.Nomcli ?? string.Empty,
                            Ruc = e.Ruc ?? string.Empty,
                            Dircli = e.Dircli ?? string.Empty,
                            Fecing = e.Fecing,

                            ZonaReferencia = e.ZonaReferencia ?? string.Empty,
                            EstadoNombre = e.EstadoNombre ?? string.Empty,
                            TipoCliente = e.TipoCliente ?? string.Empty,
                            GrupoEmpresa = e.GrupoEmpresa ?? string.Empty,

                            Representante = e.Representante ?? string.Empty,
                            Telefono = e.Telefono ?? string.Empty,
                            Prefijo = e.Prefijo ?? string.Empty,

                            NPrefijo = e.NPrefijo,

                            CheckPrefijo = adicional != null &&
                                           ConvertirBitABool(adicional.Prefijo),

                            CheckGuia = adicional != null &&
                                        ConvertirBitABool(adicional.Guia),

                            CheckOtros = adicional != null &&
                                         ConvertirBitABool(adicional.Otros)
                        };
                    })
                    .ToList();

                return new ApiResponse<IEnumerable<ClientesExploradorResponse>>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    data,
                    null,
                    totalRegistros
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ClientesExploradorResponse>>.Error(
                    $"Error al obtener los clientes: {ex.Message}");
            }
        }

        private static bool ConvertirBitABool(object? value)
        {
            if (value == null)
                return false;

            if (value is bool boolValue)
                return boolValue;

            if (value is int intValue)
                return intValue == 1;

            if (value is short shortValue)
                return shortValue == 1;

            if (value is byte byteValue)
                return byteValue == 1;

            var texto = Convert.ToString(value)?.Trim();

            if (string.IsNullOrWhiteSpace(texto))
                return false;

            if (texto == "1")
                return true;

            if (texto == "0")
                return false;

            return bool.TryParse(texto, out var result) && result;
        }
    }
}