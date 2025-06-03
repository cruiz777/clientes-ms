using AutoMapper;
using clientes_ms.Application.Queries.Gln;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetGlnByPrefijoIdHandler : IRequestHandler<GetGlnByPrefijoIdQuery, ApiResponse<GlnResponse>>
{
    private readonly IBaseRepository<Gln> _repository;
    private readonly IMapper _mapper;

    public GetGlnByPrefijoIdHandler(IBaseRepository<Gln> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<GlnResponse>> Handle(GetGlnByPrefijoIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var gln = await _repository.FirstOrDefaultAsync(g => g.IdPrefijos == request.IdPrefijos);

            if (gln == null)
            {
                return new ApiResponse<GlnResponse>(
                    Guid.NewGuid(),
                    "NOT_FOUND",
                    null,
                    "No se encontró un GLN con el prefijo proporcionado."
                );
            }

            var result = _mapper.Map<GlnResponse>(gln);

            return new ApiResponse<GlnResponse>(
                Guid.NewGuid(),
                "OK",
                result,
                "GLN recuperado correctamente por ID de prefijo."
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<GlnResponse>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al recuperar GLN por ID de prefijo: {ex.Message}"
            );
        }
    }
}
