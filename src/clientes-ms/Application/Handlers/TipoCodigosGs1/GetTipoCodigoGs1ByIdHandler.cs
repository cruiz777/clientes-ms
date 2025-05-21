using AutoMapper;
using clientes_ms.Application.Queries.TipoCodigoGs1;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.TipoCodigosGs1;

public class GetTipoCodigoGs1ByIdHandler : IRequestHandler<GetTipoCodigoGs1ByIdQuery, ApiResponse<TipoCodigoGs1Response>>
{
    private readonly IBaseRepository<TipoCodigoGs1> _repository;
    private readonly IMapper _mapper;

    public GetTipoCodigoGs1ByIdHandler(IBaseRepository<TipoCodigoGs1> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<TipoCodigoGs1Response>> Handle(GetTipoCodigoGs1ByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return new ApiResponse<TipoCodigoGs1Response>(Guid.NewGuid(), "OBJECT", null, $"TipoCodigoGs1 with ID {request.Id} not found.");
            }

            var result = _mapper.Map<TipoCodigoGs1Response>(entity);
            return new ApiResponse<TipoCodigoGs1Response>(Guid.NewGuid(), "OBJECT", result, "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoCodigoGs1Response>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
