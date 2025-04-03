using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetNumeroControlByIdHandler : IRequestHandler<GetNumeroControlByIdQuery, ApiResponse<NumeroControlResponse>>
{
    private readonly IBaseRepository<NumeroControl> _repository;
    public GetNumeroControlByIdHandler(IBaseRepository<NumeroControl> repository) => _repository = repository;

    public async Task<ApiResponse<NumeroControlResponse>> Handle(GetNumeroControlByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<NumeroControlResponse>(Guid.NewGuid(), "OBJECT", null, $"NumeroControl with ID {request.Id} not found.");
            return new ApiResponse<NumeroControlResponse>(Guid.NewGuid(), "OBJECT", new NumeroControlResponse(e.IdNumeroControl, e.Codcon??0, e.Modcon?.Trim() ??string.Empty, e.Tipcon?.Trim() ?? string.Empty, e.Numcon?.Trim() ?? string.Empty, e.Ocupado??false, e.EmpresaCodigo ?? 0), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<NumeroControlResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}