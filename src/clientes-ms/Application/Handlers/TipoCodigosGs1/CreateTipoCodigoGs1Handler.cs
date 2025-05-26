using AutoMapper;
using clientes_ms.Application.Commands.TipoCodigoGs1;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.TipoCodigosGs1;

public class CreateTipoCodigoGs1Handler : IRequestHandler<CreateTipoCodigoGs1Command, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoCodigoGs1> _repository;
    private readonly IMapper _mapper;

    public CreateTipoCodigoGs1Handler(IBaseRepository<TipoCodigoGs1> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<bool>> Handle(CreateTipoCodigoGs1Command request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<TipoCodigoGs1>(request.Request);
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}
