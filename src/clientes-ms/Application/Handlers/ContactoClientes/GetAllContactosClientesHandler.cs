using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllContactosClientesHandler : IRequestHandler<GetAllContactosClientesQuery, ApiResponse<IEnumerable<ContactosClientesResponse>>>
{
    private readonly IBaseRepository<ContactosClientes> _repository;
    public GetAllContactosClientesHandler(IBaseRepository<ContactosClientes> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<ContactosClientesResponse>>> Handle(GetAllContactosClientesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<ContactosClientesResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ContactosClientesResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static ContactosClientesResponse MapToResponse(ContactosClientes e) => new(e.IdContactosClientes, e.Nombre?.Trim() ?? string.Empty, e.Telefono?.Trim() ?? string.Empty, e.Email?.Trim() ?? string.Empty, e.Cargo?.Trim() ?? string.Empty, e.ClientesCodigo??0);
}