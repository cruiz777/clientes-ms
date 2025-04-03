using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetProvinciaByIdHandler : IRequestHandler<GetProvinciaByIdQuery, ApiResponse<ProvinciaResponse>>
{
    private readonly IBaseRepository<Provincia> _repository;
    public GetProvinciaByIdHandler(IBaseRepository<Provincia> repository) => _repository = repository;

    public async Task<ApiResponse<ProvinciaResponse>> Handle(GetProvinciaByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<ProvinciaResponse>(Guid.NewGuid(), "OBJECT", null, $"Provincia with ID {request.Id} not found.");
            return new ApiResponse<ProvinciaResponse>(Guid.NewGuid(), "OBJECT", new ProvinciaResponse(e.IdProvincia, e.Referencia?.Trim() ?? string.Empty, e.Nombre?.Trim() ?? string.Empty,e.IdPais), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<ProvinciaResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}