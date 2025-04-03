using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllVendedorHandler : IRequestHandler<GetAllVendedorQuery, ApiResponse<IEnumerable<VendedorResponse>>>
{
    private readonly IBaseRepository<Vendedor> _repository;
    public GetAllVendedorHandler(IBaseRepository<Vendedor> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<VendedorResponse>>> Handle(GetAllVendedorQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<VendedorResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<VendedorResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static VendedorResponse MapToResponse(Vendedor e) => new(e.IdVendedor, e.Nombre?.Trim() ?? string.Empty, e.Ruc?.Trim() ?? string.Empty, e.PorVendedor?.Trim() ?? string.Empty,e.Fecing?? DateOnly.MinValue, e.Fecsal?? DateOnly.MinValue, e.Estado ?? 0, e.EmpresaCodigo ?? 0);
}