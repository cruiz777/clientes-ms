using AutoMapper;
using clientes_ms.Application.Queries.Gln;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetGlnByPrefijoIdHandler : IRequestHandler<GetGlnByPrefijoIdQuery, ApiResponse<List<GlnResponse>>>
{
    private readonly IBaseRepository<Gln> _repository;
    private readonly IMapper _mapper;

    public GetGlnByPrefijoIdHandler(IBaseRepository<Gln> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<GlnResponse>>> Handle(GetGlnByPrefijoIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var glns = await _repository.GetListByConditionAsync(g => g.IdPrefijos == request.IdPrefijos);

            if (glns == null || glns.Count == 0)
            {
                return new ApiResponse<List<GlnResponse>>(
                    Guid.NewGuid(),
                    "NOT_FOUND",
                    null,
                    "No se encontraron GLNs con el prefijo proporcionado."
                );
            }

            var result = _mapper.Map<List<GlnResponse>>(glns);

            return new ApiResponse<List<GlnResponse>>(
                Guid.NewGuid(),
                "OK",
                result,
                "GLNs recuperados correctamente por ID de prefijo."
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<GlnResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al recuperar GLNs por ID de prefijo: {ex.Message}"
            );
        }
    }
}

