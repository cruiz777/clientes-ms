using clientes_ms.Application.DTOs.Clientes;
using clientes_ms.Application.Queries.Clientes;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using System.Text.RegularExpressions;

namespace clientes_ms.Application.Handlers.Cliente
{
    public class ValidarClientesSriMasivoQueryHandler : IRequestHandler<ValidarClientesSriMasivoQuery, ApiResponse<List<ClienteValidadoResultadoDTO>>>
    {
        private readonly IBaseRepository<Clientes> _repository;
        private readonly IClienteDomainService _clienteDomainService;

        public ValidarClientesSriMasivoQueryHandler(
            IBaseRepository<Clientes> repository,
            IClienteDomainService clienteDomainService)
        {
            _repository = repository;
            _clienteDomainService = clienteDomainService;
        }

        public async Task<ApiResponse<List<ClienteValidadoResultadoDTO>>> Handle(ValidarClientesSriMasivoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Carga SECUNCIAL de los clientes válidos (solo acceso a DbContext aquí)
                var clientesValidos = new List<(long Id, string Ruc)>();

                foreach (var id in request.ClienteIds)
                {
                    var cliente = await _repository.GetByIdAsync(id);
                    if (cliente == null || string.IsNullOrWhiteSpace(cliente.Ruc))
                        continue;

                    var ruc = cliente.Ruc.Trim();
                    if (Regex.IsMatch(ruc, @"^\d{13}$"))
                    {
                        clientesValidos.Add((id, ruc));
                    }
                }

                // 2. Validación en paralelo SOLO al servicio del SRI
                var tareas = clientesValidos.Select(async c =>
                {
                    var validado = await _clienteDomainService.ValidarClienteDesdeSriAsync(c.Ruc);
                    return validado != null ? new ClienteValidadoResultadoDTO(c.Id, validado) : null;
                });

                var resultadosParciales = await Task.WhenAll(tareas);
                var resultados = resultadosParciales.Where(r => r != null).ToList();

                return new ApiResponse<List<ClienteValidadoResultadoDTO>>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    resultados!,
                    "Clientes validados correctamente",
                    resultados.Count);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ClienteValidadoResultadoDTO>>(
                    Guid.NewGuid(),
                    "ERROR",
                    null,
                    $"Ocurrió un error durante la validación masiva: {ex.Message}");
            }
        }

    }
}
