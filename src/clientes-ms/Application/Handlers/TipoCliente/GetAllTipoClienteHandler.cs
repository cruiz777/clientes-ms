using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllTipoClienteHandler : IRequestHandler<GetAllTipoClienteQuery, ApiResponse<IEnumerable<TipoClienteResponse>>>
{
    private readonly IBaseRepository<TipoCliente> _repository;

    public GetAllTipoClienteHandler(IBaseRepository<TipoCliente> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<TipoClienteResponse>>> Handle(GetAllTipoClienteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var tipoClientes = await _repository
                .AsQueryable()
                .Include(tc => tc.IdEmpresaNavigation)
                .ToListAsync(cancellationToken); // Aplica ToListAsync sobre la entidad primero

            var result = tipoClientes.Select(MapToResponse); // Luego haces el Select a tu DTO

            return new ApiResponse<IEnumerable<TipoClienteResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TipoClienteResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }


    private static TipoClienteResponse MapToResponse(TipoCliente e) => new(
        id_tipo_cliente: e.IdTipoCliente,
        descripcion: e.Descripcion?.Trim() ?? string.Empty,
        cuenta: e.Cuenta ?? string.Empty,
        id_empresa: e.IdEmpresa ?? 0,
        estado: e.Estado ?? false,
        empresa: e.IdEmpresaNavigation?.Nombre?.Trim() ?? string.Empty
    );
}
