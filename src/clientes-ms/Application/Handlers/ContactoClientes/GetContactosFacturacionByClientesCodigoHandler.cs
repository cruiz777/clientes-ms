using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetContactosFacturacionByClientesCodigoHandler
    : IRequestHandler<GetContactosFacturacionByClientesCodigoQuery, ApiResponse<List<ContactosClientesResponse>>>
{
    private readonly IBaseRepository<ContactosClientes> _repository;

    public GetContactosFacturacionByClientesCodigoHandler(IBaseRepository<ContactosClientes> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<List<ContactosClientesResponse>>> Handle(GetContactosFacturacionByClientesCodigoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var contactos = await _repository.AsQueryable()
                .Where(c => c.ClientesCodigo == request.ClientesCodigo
                            && c.Cargo != null
                            && c.Cargo.Trim().ToLower() == "facturación"
                            && new[] {  2, 3, 4 }.Contains(c.Linea ?? 0))
                .ToListAsync(cancellationToken);

            var result = contactos.Select(e => new ContactosClientesResponse(
                e.IdContactosClientes,
                e.Nombre?.Trim() ?? string.Empty,
                e.Telefono?.Trim() ?? string.Empty,
                e.Email?.Trim() ?? string.Empty,
                e.Cargo?.Trim() ?? string.Empty,
                e.ClientesCodigo ?? 0,
                e.Linea ?? 0
            )).ToList();

            return new ApiResponse<List<ContactosClientesResponse>>(Guid.NewGuid(), "LIST", result, "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<ContactosClientesResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
