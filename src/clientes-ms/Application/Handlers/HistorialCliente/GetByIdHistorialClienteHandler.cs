using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class GetHistorialClienteByIdHandler : IRequestHandler<GetHistorialClienteByIdQuery, ApiResponse<HistorialClienteResponse>>
{
    private readonly IBaseRepository<HistorialCliente> _repository;
    public GetHistorialClienteByIdHandler(IBaseRepository<HistorialCliente> repository) => _repository = repository;

    public async Task<ApiResponse<HistorialClienteResponse>> Handle(GetHistorialClienteByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository
                .AsQueryable()
                .Include(tc => tc.ClientesCodigoNavigation)
                .FirstOrDefaultAsync(tc => tc.IdHistorialCliente == request.Id, cancellationToken);

            if (e == null)
                return new ApiResponse<HistorialClienteResponse>(Guid.NewGuid(), "OBJECT", null, $"HistorialCliente with ID {request.Id} not found.");

            var response = new HistorialClienteResponse(
               id_historial_cliente: e.IdHistorialCliente, id_usuario: e.IdUsuario ?? 0, nombre_usuario: e.NombreUsuario, fecha: e.Fecha ?? DateTime.Now, descripcion: e.Descripcion?.Trim() ?? string.Empty,
        clientes_codigo: e.ClientesCodigo ?? 0, cliente: e.ClientesCodigoNavigation?.Nomcli?.Trim() ?? string.Empty
            );

            return new ApiResponse<HistorialClienteResponse>(Guid.NewGuid(), "OBJECT", response, "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<HistorialClienteResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}