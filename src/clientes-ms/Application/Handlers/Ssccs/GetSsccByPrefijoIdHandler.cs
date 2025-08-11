using AutoMapper;
using AutoMapper.QueryableExtensions;
using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers.Ssccs;

public class GetSsccByPrefijoHandler : IRequestHandler<GetSsccByPrefijoQuery, ApiResponse<PaginationResponse<SsccResponse>>>
{
    private readonly IBaseRepository<Sscc> _repository;
    private readonly IMapper _mapper;

    public GetSsccByPrefijoHandler(IBaseRepository<Sscc> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<PaginationResponse<SsccResponse>>> Handle(GetSsccByPrefijoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var page = request.Page <= 0 ? 1 : request.Page;
            var pageSize = request.PageSize <= 0 ? 50 : Math.Min(request.PageSize, 1000);
            var skip = (page - 1) * pageSize;

            var query = _repository.AsQueryable()
                .Where(s => s.IdPrefijo == request.IdPrefijo)
                .AsNoTracking();

            var totalItems = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(s => s.IdSscc)
                .Skip(skip)
                .Take(pageSize)
                .ProjectTo<SsccResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var pagination = new PaginationResponse<SsccResponse>(
                items: items,
                page: page,
                pageSize: pageSize,
                totalItems: totalItems,
                message: "SSCC por prefijo paginados correctamente"
            );

            return new ApiResponse<PaginationResponse<SsccResponse>>(
                Id: Guid.NewGuid(),
                Type: "PAGINATION",
                Data: pagination,
                Message: "SSCC encontrados correctamente",
                Count: items.Count
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<PaginationResponse<SsccResponse>>.Error($"Error al obtener los SSCCs por prefijo: {ex.Message}");
        }
    }
}
