using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetVendedorByIdHandler : IRequestHandler<GetVendedorByIdQuery, ApiResponse<VendedorResponse>>
{
    private readonly IBaseRepository<Vendedor> _repository;
    public GetVendedorByIdHandler(IBaseRepository<Vendedor> repository) => _repository = repository;

    public async Task<ApiResponse<VendedorResponse>> Handle(GetVendedorByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<VendedorResponse>(Guid.NewGuid(), "OBJECT", null, $"Vendedor with ID {request.Id} not found.");
            return new ApiResponse<VendedorResponse>(Guid.NewGuid(), "OBJECT", new VendedorResponse(e.IdVendedor, e.Nombre?.Trim() ?? string.Empty, e.Ruc?.Trim() ?? string.Empty, e.PorVendedor?.Trim() ?? string.Empty, e.Fecing?? DateOnly.MinValue, e.Fecsal?? DateOnly.MinValue, e.Estado?? 0, e.EmpresaCodigo ?? 0), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<VendedorResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}