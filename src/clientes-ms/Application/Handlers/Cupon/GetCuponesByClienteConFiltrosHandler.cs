using AutoMapper;
using AutoMapper.QueryableExtensions;
using clientes_ms.Application.Queries.Cupon;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers.Cupon
{
    public class GetCuponesByClienteConFiltrosHandler : IRequestHandler<GetCuponesByClienteConFiltrosQuery, ApiResponse<PaginationResponse<CuponResponse>>>
    {
        private readonly IBaseRepository<Cupones> _repository;
        private readonly IMapper _mapper;

        public GetCuponesByClienteConFiltrosHandler(IBaseRepository<Cupones> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<PaginationResponse<CuponResponse>>> Handle(GetCuponesByClienteConFiltrosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var page = request.Page <= 0 ? 1 : request.Page;
                var pageSize = request.PageSize <= 0 ? 50 : Math.Min(request.PageSize, 1000);
                var skip = (page - 1) * pageSize;

                // Incluye la navegación a Prefijos si deseas acceder a su contenido en filtros o en el mapper
                var query = _repository.AsQueryable()
                    .Where(c => c.IdCliente == request.IdCliente)
                    .Include(c => c.IdPrefijoNavigation)
                    .AsNoTracking();

                query = AplicarFiltros(query, request);

                var totalItems = await query.CountAsync(cancellationToken);

                var pagedItems = await query
                    .OrderByDescending(c => c.IdCupon)
                    .Skip(skip)
                    .Take(pageSize)
                    .ProjectTo<CuponResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var pagination = new PaginationResponse<CuponResponse>(
                    items: pagedItems,
                    page: page,
                    pageSize: pageSize,
                    totalItems: totalItems,
                    message: "Cupones filtrados y paginados correctamente"
                );

                return new ApiResponse<PaginationResponse<CuponResponse>>(
                    Id: Guid.NewGuid(),
                    Type: "PAGINATION",
                    Data: pagination,
                    Message: "Cupones encontrados correctamente",
                    Count: pagedItems.Count
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<PaginationResponse<CuponResponse>>.Error($"Error al obtener los cupones con filtros: {ex.Message}");
            }
        }

        private IQueryable<Cupones> AplicarFiltros(IQueryable<Cupones> query, GetCuponesByClienteConFiltrosQuery request)
        {
            if (request.IdPrefijo.HasValue)
                query = query.Where(c => c.IdPrefijo == request.IdPrefijo.Value);

            if (!string.IsNullOrWhiteSpace(request.Busqueda))
            {
                var busqueda = request.Busqueda.Trim();

                // Búsqueda simple con Contains (recomendada)
                query = query.Where(c =>
                    c.CodigoCupon.Contains(busqueda) ||
                    (c.IdPrefijoNavigation != null && c.IdPrefijoNavigation.Codpre != null && c.IdPrefijoNavigation.Codpre.Contains(busqueda)) ||
                    EF.Functions.Like(c.Serial.ToString(), $"%{busqueda}%"));
                /*
                // Intenta convertir la búsqueda a número para Serial
                if (long.TryParse(busqueda, out var serialBuscado))
                {
                    query = query.Where(c =>
                        c.Serial == serialBuscado ||
                        c.CodigoCupon.Contains(busqueda) ||
                        (c.IdPrefijoNavigation != null && c.IdPrefijoNavigation.Codpre != null && c.IdPrefijoNavigation.Codpre.Contains(busqueda)));
                }
                else
                {
                    query = query.Where(c =>
                        c.CodigoCupon.Contains(busqueda) ||
                        (c.IdPrefijoNavigation != null && c.IdPrefijoNavigation.Codpre != null && c.IdPrefijoNavigation.Codpre.Contains(busqueda)));
                }
                */

                //Búsqueda más robusta con SqlServer
                /*
                query = query.Where(c =>
                    EF.Functions.Like(c.CodigoCupon, $"%{busqueda}%") ||
                    (c.IdPrefijoNavigation != null && c.IdPrefijoNavigation.Codpre != null && EF.Functions.Like(c.IdPrefijoNavigation.Codpre, $"%{busqueda}%")) ||
                    EF.Functions.Like(EF.Functions.Collate(c.Serial.ToString(), "SQL_Latin1_General_CP1_CI_AS"), $"%{busqueda}%"));
                */
            }

            if (request.SerialDesde.HasValue)
                query = query.Where(c => c.Serial >= request.SerialDesde.Value);

            if (request.SerialHasta.HasValue)
                query = query.Where(c => c.Serial <= request.SerialHasta.Value);

            if (request.Estado.HasValue)
                query = query.Where(c => c.Estado == request.Estado.Value);

            if (request.FechaInicioDesde.HasValue)
                query = query.Where(c => c.FechaInicio >= request.FechaInicioDesde.Value);

            if (request.FechaInicioHasta.HasValue)
                query = query.Where(c => c.FechaInicio <= request.FechaInicioHasta.Value);

            if (request.FechaCaducidadDesde.HasValue)
                query = query.Where(c => c.FechaCaducidad.HasValue && c.FechaCaducidad.Value >= request.FechaCaducidadDesde.Value);

            if (request.FechaCaducidadHasta.HasValue)
                query = query.Where(c => c.FechaCaducidad.HasValue && c.FechaCaducidad.Value <= request.FechaCaducidadHasta.Value);

            return query;
        }
    }
}