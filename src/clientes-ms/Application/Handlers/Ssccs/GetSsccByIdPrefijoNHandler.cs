using AutoMapper;
using AutoMapper.QueryableExtensions;
using clientes_ms.Application.Queries.Sscc;
using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;



public class GetSsccByIdPrefijoNHandler : IRequestHandler<GetSsccByIdPrefijoNQuery, ApiResponse<List<SsccResponse>>>
{
    private readonly IBaseRepository<Sscc> _repository;
    private readonly IMapper _mapper;

    public GetSsccByIdPrefijoNHandler(
        IBaseRepository<Sscc> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<SsccResponse>>> Handle(GetSsccByIdPrefijoNQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Consulta filtrando por IdPrefijo
            var query = _repository.AsQueryable()
                .Where(s => s.IdPrefijo == request.IdPrefijo)
                .OrderByDescending(s => s.FechaCreacion);

            // Ejecutar consulta y mapear con AutoMapper
            var ssccList = await query
                .ProjectTo<SsccResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ApiResponse<List<SsccResponse>>(
                Id: Guid.NewGuid(),
                Type: "LIST",
                Data: ssccList,
                Message: "SSCC encontrados correctamente",
                Count: ssccList.Count
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<SsccResponse>>.Error($"Error al obtener los SSCC: {ex.Message}");
        }
    }

}
