using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllTipoClienteHandler : IRequestHandler<GetAllTipoClienteQuery, ApiResponse<IEnumerable<TipoClienteResponse>>>
{
    private readonly IBaseRepository<TipoCliente> _repository;
    public GetAllTipoClienteHandler(IBaseRepository<TipoCliente> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<TipoClienteResponse>>> Handle(GetAllTipoClienteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<TipoClienteResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TipoClienteResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static TipoClienteResponse MapToResponse(TipoCliente e) => new(e.IdTipoCliente, e.Descripcion?.Trim() ?? string.Empty,e.Cuenta?? string.Empty,e.IdEmpresa??0,e.Estado??false, e.IdEmpresaNavigation?.Nombre ?? string.Empty
);
}