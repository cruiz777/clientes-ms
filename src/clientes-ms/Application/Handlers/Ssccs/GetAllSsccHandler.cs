using AutoMapper;
using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.Ssccs
{
    public class GetAllSsccHandler : IRequestHandler<GetAllSsccQuery, ApiResponse<IEnumerable<SsccResponse>>>
    {
        private readonly IBaseRepository<Sscc> _repository;
        private readonly IMapper _mapper;

        public GetAllSsccHandler(IBaseRepository<Sscc> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<SsccResponse>>> Handle(GetAllSsccQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetAllAsync();
                var mapped = _mapper.Map<IEnumerable<SsccResponse>>(result);
                return new ApiResponse<IEnumerable<SsccResponse>>(Guid.NewGuid(), "SUCCESS", mapped, "Consulta realizada correctamente");
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<SsccResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
            }
        }
    }
}
