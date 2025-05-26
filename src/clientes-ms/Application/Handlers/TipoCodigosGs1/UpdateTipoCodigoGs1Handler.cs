using AutoMapper;
using clientes_ms.Application.Commands.TipoCodigoGs1;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.TipoCodigosGs1
{
    public class UpdateTipoCodigoGs1Handler : IRequestHandler<UpdateTipoCodigoGs1Command, ApiResponse<bool>>
    {
        private readonly IBaseRepository<TipoCodigoGs1> _repository;
        private readonly IMapper _mapper;

        public UpdateTipoCodigoGs1Handler(IBaseRepository<TipoCodigoGs1> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateTipoCodigoGs1Command request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null)
                {
                    return new ApiResponse<bool>(Guid.NewGuid(), "OBJECT", false, $"TipoCodigoGs1 with ID {request.Id} not found.");
                }

                _mapper.Map(request.Request, entity);
                await _repository.UpdateAsync(request.Id, entity);

                return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Updated successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
            }
        }
    }
}
