using AutoMapper;
using AutoMapper.QueryableExtensions;
using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers.Ssccs;

public class GetAllSsccByIdClienteHandler : IRequestHandler<GetAllSsccByIdClienteQuery, ApiResponse<PaginationResponse<SsccResponse>>>
{
    private readonly IBaseRepository<Sscc> _repository;
    private readonly IMapper _mapper;

    public GetAllSsccByIdClienteHandler(IBaseRepository<Sscc> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<PaginationResponse<SsccResponse>>> Handle(GetAllSsccByIdClienteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var skip = (request.Page - 1) * request.PageSize;

            var query = _repository.AsQueryable()
                .Where(s => s.IdCliente == request.IdCliente)
                .AsNoTracking();

            var totalItems = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(s => s.IdSscc)
                .Skip(skip)
                .Take(request.PageSize)
                .ProjectTo<SsccResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var pagination = new PaginationResponse<SsccResponse>(
                items: items,
                page: request.Page,
                pageSize: request.PageSize,
                totalItems: totalItems,
                message: "SSCC paginados correctamente"
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
            return ApiResponse<PaginationResponse<SsccResponse>>.Error($"Error al obtener los SSCC del cliente: {ex.Message}");
        }
    }
}
