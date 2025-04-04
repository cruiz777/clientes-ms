using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetContactosClientesByIdHandler : IRequestHandler<GetContactosClientesByIdQuery, ApiResponse<ContactosClientesResponse>>
{
    private readonly IBaseRepository<ContactosClientes> _repository;
    public GetContactosClientesByIdHandler(IBaseRepository<ContactosClientes> repository) => _repository = repository;

    public async Task<ApiResponse<ContactosClientesResponse>> Handle(GetContactosClientesByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<ContactosClientesResponse>(Guid.NewGuid(), "OBJECT", null, $"ContactoClientes with ID {request.Id} not found.");
            return new ApiResponse<ContactosClientesResponse>(Guid.NewGuid(), "OBJECT", new ContactosClientesResponse(e.IdContactosClientes, e.Nombre?.Trim() ?? string.Empty, e.Telefono?.Trim() ?? string.Empty, e.Email?.Trim() ?? string.Empty, e.Cargo?.Trim() ?? string.Empty, e.ClientesCodigo??0), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<ContactosClientesResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}