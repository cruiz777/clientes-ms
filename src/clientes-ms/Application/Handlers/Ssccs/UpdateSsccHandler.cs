using AutoMapper;
using clientes_ms.Application.Commands.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.Ssccs;

public class UpdateSsccHandler : IRequestHandler<UpdateSsccCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Sscc> _repository;
    private readonly IMapper _mapper;

    public UpdateSsccHandler(IBaseRepository<Sscc> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateSsccCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return new ApiResponse<bool>(Guid.NewGuid(), "NOT_FOUND", false, "No se encontró el SSCC.");

            _mapper.Map(request.Request, entity);
            await _repository.UpdateAsync(request.Id, entity);

            return new ApiResponse<bool>(Guid.NewGuid(), "SUCCESS", true, "SSCC actualizado correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}
