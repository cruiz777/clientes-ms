using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;
using System.Collections.Generic;

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
            var historial = await _repository
                .AsQueryable()
                .Include(h => h.ClientesCodigoNavigation)
                .Where(h => h.ClientesCodigo == request.ClientesCodigo)
                .OrderByDescending(h => h.Fecha)
                .ToListAsync(cancellationToken);

            var response = historial.Select(e => new HistorialClienteResponse(
                id_historial_cliente: e.IdHistorialCliente,
                id_usuario: e.IdUsuario ?? 0,
                nombre_usuario: e.NombreUsuario??string.Empty,
                fecha: e.Fecha ?? DateTime.Now,
                descripcion: e.Descripcion?.Trim() ?? string.Empty,
                clientes_codigo: e.ClientesCodigo ?? 0,
                cliente: e.ClientesCodigoNavigation?.Nomcli?.Trim() ?? string.Empty
            ));

            return new ApiResponse<IEnumerable<HistorialClienteResponse>>(Guid.NewGuid(), "LIST", response, "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<HistorialClienteResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
