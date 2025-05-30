using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using AutoMapper;
using clientes_ms.Application.Queries.Gln;

public class GetGlnByClienteCodigoHandler : IRequestHandler<GetGlnByClienteCodigoQuery, ApiResponse<IEnumerable<GlnResponse>>>
{
    private readonly IBaseRepository<Gln> _repository;
    private readonly IMapper _mapper;

    public GetGlnByClienteCodigoHandler(IBaseRepository<Gln> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<GlnResponse>>> Handle(GetGlnByClienteCodigoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var glns = await _repository.GetListByConditionAsync(g => g.ClientesCodigo == request.ClientesCodigo);

            var result = _mapper.Map<IEnumerable<GlnResponse>>(glns);

            return new ApiResponse<IEnumerable<GlnResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                "GLNs del cliente recuperados correctamente."
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<GlnResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al obtener GLNs por cliente: {ex.Message}"
            );
        }
    }
}
