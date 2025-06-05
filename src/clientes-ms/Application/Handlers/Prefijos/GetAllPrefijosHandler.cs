using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using AutoMapper;

public class GetAllPrefijosHandler : IRequestHandler<GetAllPrefijosQuery, ApiResponse<IEnumerable<PrefijosResponse>>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    private readonly IMapper _mapper;

    public GetAllPrefijosHandler(IBaseRepository<Prefijos> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<PrefijosResponse>>> Handle(GetAllPrefijosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var prefijos = await _repository.GetAllAsync();
            var result = _mapper.Map<List<PrefijosResponse>>(prefijos);
            return new ApiResponse<IEnumerable<PrefijosResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<PrefijosResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

}