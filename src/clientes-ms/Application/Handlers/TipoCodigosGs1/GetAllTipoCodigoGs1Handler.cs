using AutoMapper;
using clientes_ms.Application.Queries.TipoCodigoGs1;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.TipoCodigosGs1;

public class GetAllTipoCodigoGs1Handler : IRequestHandler<GetAllTipoCodigoGs1Query, ApiResponse<IEnumerable<TipoCodigoGs1Response>>>
{
    private readonly IBaseRepository<TipoCodigoGs1> _repository;
    private readonly IMapper _mapper;

    public GetAllTipoCodigoGs1Handler(IBaseRepository<TipoCodigoGs1> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<TipoCodigoGs1Response>>> Handle(GetAllTipoCodigoGs1Query request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<TipoCodigoGs1Response>>(entities);

            return new ApiResponse<IEnumerable<TipoCodigoGs1Response>>(
                Guid.NewGuid(), "LIST", result, "Retrieved successfully", result.Count()
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TipoCodigoGs1Response>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
