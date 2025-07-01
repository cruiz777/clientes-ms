using AutoMapper;
using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.Ssccs;

public class GetSsccByIdHandler : IRequestHandler<GetSsccByIdQuery, ApiResponse<SsccResponse>>
{
    private readonly IBaseRepository<Sscc> _repository;
    private readonly IMapper _mapper;

    public GetSsccByIdHandler(IBaseRepository<Sscc> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<SsccResponse>> Handle(GetSsccByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return new ApiResponse<SsccResponse>(Guid.NewGuid(), "NOT_FOUND", null, "No se encontró el SSCC.");

            var mapped = _mapper.Map<SsccResponse>(entity);
            return new ApiResponse<SsccResponse>(Guid.NewGuid(), "SUCCESS", mapped, "SSCC encontrado.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<SsccResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
