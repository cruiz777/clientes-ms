using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetCantonByIdHandler : IRequestHandler<GetCantonesByIdQuery, ApiResponse<CantonesResponse>>
{
    private readonly IBaseRepository<Cantones> _repository;
    public GetCantonByIdHandler(IBaseRepository<Cantones> repository) => _repository = repository;

    public async Task<ApiResponse<CantonesResponse>> Handle(GetCantonesByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<CantonesResponse>(Guid.NewGuid(), "OBJECT", null, $"Canton with ID {request.Id} not found.");
            return new ApiResponse<CantonesResponse>(Guid.NewGuid(), "OBJECT", new CantonesResponse(e.IdCanton, e.Referencia?.Trim() ?? string.Empty, e.Nombre?.Trim() ?? string.Empty,e.IdProvincia), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<CantonesResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}