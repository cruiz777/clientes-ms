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

public class GetAllCuponesByIdClienteHandler : IRequestHandler<GetAllCuponesByIdClienteQuery, ApiResponse<PaginationResponse<CuponResponse>>>
{
    private readonly IBaseRepository<Cupones> _repository;
    private readonly IMapper _mapper;
    private readonly ICuponDomainService _cuponDomainService;

    public GetAllCuponesByIdClienteHandler(
        IBaseRepository<Cupones> repository,
        IMapper mapper,
        ICuponDomainService cuponDomainService)
    {
        _repository = repository;
        _mapper = mapper;
        _cuponDomainService = cuponDomainService;
    }

    public async Task<ApiResponse<PaginationResponse<CuponResponse>>> Handle(GetAllCuponesByIdClienteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var skip = (request.Page - 1) * request.PageSize;

            var query = _repository.AsQueryable()
                .Where(c => c.IdCliente == request.IdCliente)
                .OrderByDescending(c => c.IdCupon);

            var totalItems = await query.CountAsync(cancellationToken);

            // Tomar solo los cupones necesarios para la página actual
            var cupones = await query
                .Skip(skip)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            // Validar cupones y actualizar los que estén caducados
            foreach (var cupon in cupones)
            {
                bool vigente = _cuponDomainService.EsCuponVigente(cupon.FechaInicio, cupon.FechaCaducidad);

                if (!vigente && cupon.Estado) // Si ya no es vigente y aún tiene estado true
                {
                    cupon.Estado = false;
                    await _repository.UpdateAsync(cupon.IdCupon, cupon); // Actualiza en la base
                }
            }

            // Ahora proyectamos (usamos _mapper) con los ya procesados
            var items = cupones
                .AsQueryable()
                .ProjectTo<CuponResponse>(_mapper.ConfigurationProvider)
                .ToList();

            var pagination = new PaginationResponse<CuponResponse>(
                items: items,
                page: request.Page,
                pageSize: request.PageSize,
                totalItems: totalItems,
                message: "Cupones paginados correctamente"
            );

            return new ApiResponse<PaginationResponse<CuponResponse>>(
                Id: Guid.NewGuid(),
                Type: "PAGINATION",
                Data: pagination,
                Message: "Cupones encontrados correctamente",
                Count: items.Count
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<PaginationResponse<CuponResponse>>.Error($"Error al obtener los cupones del cliente: {ex.Message}");
        }
    }
}
