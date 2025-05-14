using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

public class GetAllHistorialClienteHandler : IRequestHandler<GetAllHistorialClienteQuery, ApiResponse<IEnumerable<HistorialClienteResponse>>>
{
    private readonly IBaseRepository<HistorialCliente> _repository;

    public GetAllHistorialClienteHandler(IBaseRepository<HistorialCliente> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<HistorialClienteResponse>>> Handle(GetAllHistorialClienteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var HistorialClientes = await _repository
                .AsQueryable()
                .Include(tc => tc.ClientesCodigoNavigation)
                .ToListAsync(cancellationToken); // Aplica ToListAsync sobre la entidad primero

            var result = HistorialClientes.Select(MapToResponse); // Luego haces el Select a tu DTO

            return new ApiResponse<IEnumerable<HistorialClienteResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<HistorialClienteResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }


    private static HistorialClienteResponse MapToResponse(HistorialCliente e) => new(
        id_historial_cliente: e.IdHistorialCliente, id_usuario: e.IdUsuario ?? 0, nombre_usuario: e.NombreUsuario, fecha: e.Fecha ?? DateTime.Now, descripcion: e.Descripcion?.Trim() ?? string.Empty,
        clientes_codigo: e.ClientesCodigo ?? 0, cliente: e.ClientesCodigoNavigation?.Nomcli?.Trim() ?? string.Empty
    );
}
