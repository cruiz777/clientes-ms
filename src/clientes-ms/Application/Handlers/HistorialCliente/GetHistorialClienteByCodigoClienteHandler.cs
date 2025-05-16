using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetHistorialClienteByCodigoClienteHandler
    : IRequestHandler<GetHistorialClienteByCodigoClienteQuery, ApiResponse<IEnumerable<HistorialClienteResponse>>>
{
    private readonly IBaseRepository<HistorialCliente> _repository;

    public GetHistorialClienteByCodigoClienteHandler(IBaseRepository<HistorialCliente> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<HistorialClienteResponse>>> Handle(GetHistorialClienteByCodigoClienteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository
                .AsQueryable()
                .Include(h => h.ClientesCodigoNavigation)
                .Where(h => h.ClientesCodigo == request.ClientesCodigo);

            if (!string.IsNullOrEmpty(request.TipoAccion))
            {
                query = query.Where(h => h.TipoAccion != null && h.TipoAccion.Contains(request.TipoAccion));
            }

            if (!string.IsNullOrEmpty(request.Tabla))
            {
                query = query.Where(h => h.Tabla != null && h.Tabla.Contains(request.Tabla));
            }

            if (request.IdEmpresa != 0) // Asume que si no se manda, es 0 por defecto
            {
                query = query.Where(h => h.IdEmpresa == request.IdEmpresa);
            }

            var historial = await query
                .OrderByDescending(h => h.Fecha)
                .ToListAsync(cancellationToken);

            var response = historial.Select(e => new HistorialClienteResponse(
                id_historial_cliente: e.IdHistorialCliente,
                id_usuario: e.IdUsuario ?? 0,
                nombre_usuario: e.NombreUsuario ?? string.Empty,
                fecha: e.Fecha ?? DateTime.Now,
                descripcion: e.Descripcion?.Trim() ?? string.Empty,
                clientes_codigo: e.ClientesCodigo ?? 0,
                cliente: e.ClientesCodigoNavigation?.Nomcli?.Trim() ?? string.Empty,
                tabla: e.Tabla ?? string.Empty,
                tipo_accion: e.TipoAccion ?? string.Empty,
                id_empresa: e.IdEmpresa ?? 0
            ));

            return new ApiResponse<IEnumerable<HistorialClienteResponse>>(Guid.NewGuid(), "LIST", response, "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<HistorialClienteResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
