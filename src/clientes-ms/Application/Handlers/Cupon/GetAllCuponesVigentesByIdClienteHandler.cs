using AutoMapper;
using AutoMapper.QueryableExtensions;
using clientes_ms.Application.Queries.Cupon;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers.Cupon;

public class GetAllCuponesVigentesByIdClienteHandler : IRequestHandler<GetAllCuponesVigentesByIdClienteQuery, ApiResponse<PaginationResponse<CuponResponse>>>
{
    private readonly IBaseRepository<Cupones> _repository;
    private readonly ICuponDomainService _cuponDomainService;
    private readonly IMapper _mapper;

    public GetAllCuponesVigentesByIdClienteHandler(
        IBaseRepository<Cupones> repository,
        ICuponDomainService cuponDomainService,
        IMapper mapper)
    {
        _repository = repository;
        _cuponDomainService = cuponDomainService;
        _mapper = mapper;
    }

    public async Task<ApiResponse<PaginationResponse<CuponResponse>>> Handle(GetAllCuponesVigentesByIdClienteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var hoy = DateOnly.FromDateTime(DateTime.Today);

            var query = _repository.AsQueryableNoTracking()
                .Where(c => c.IdCliente == request.IdCliente &&
                            c.FechaInicio <= hoy &&
                            (!c.FechaCaducidad.HasValue || hoy <= c.FechaCaducidad.Value));

            var totalItems = await query.CountAsync(cancellationToken);

            var skip = (request.Page - 1) * request.PageSize;

            var items = await query
                .OrderByDescending(c => c.IdCupon)
                .Skip(skip)
                .Take(request.PageSize)
                .ProjectTo<CuponResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var pagination = new PaginationResponse<CuponResponse>(
                items: items,
                page: request.Page,
                pageSize: request.PageSize,
                totalItems: totalItems,
                message: "Cupones vigentes paginados correctamente"
            );

            return new ApiResponse<PaginationResponse<CuponResponse>>(
                Id: Guid.NewGuid(),
                Type: "PAGINATION",
                Data: pagination,
                Message: "Cupones vigentes encontrados correctamente",
                Count: items.Count
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<PaginationResponse<CuponResponse>>.Error($"Error al obtener los cupones vigentes del cliente: {ex.Message}");
        }
    }
}
