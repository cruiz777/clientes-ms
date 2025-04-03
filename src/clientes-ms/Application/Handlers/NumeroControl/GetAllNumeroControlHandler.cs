using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllNumeroControlHandler : IRequestHandler<GetAllNumeroControlQuery, ApiResponse<IEnumerable<NumeroControlResponse>>>
{
    private readonly IBaseRepository<NumeroControl> _repository;
    public GetAllNumeroControlHandler(IBaseRepository<NumeroControl> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<NumeroControlResponse>>> Handle(GetAllNumeroControlQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<NumeroControlResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<NumeroControlResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static NumeroControlResponse MapToResponse(NumeroControl e) => new(e.IdNumeroControl,e.Codcon??0, e.Modcon?.Trim() ?? string.Empty, e.Tipcon?.Trim() ?? string.Empty, e.Numcon?.Trim() ?? string.Empty, e.Ocupado??false,e.EmpresaCodigo??0);
}