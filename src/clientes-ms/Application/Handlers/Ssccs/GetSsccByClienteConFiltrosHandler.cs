using AutoMapper;
using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Infrastructure.Services;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Services;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers
{
    public class GetSsccByClienteConFiltrosHandler : IRequestHandler<GetSsccByClienteConFiltrosQuery, ApiResponse<PaginationResponse<SsccResponse>>>
    {
        private readonly IBaseRepository<Sscc> _repository;
        private readonly IMapper _mapper;
        private readonly ISsccDomainService _ssccDomainService;
        private readonly IPaginationService _paginationService;

        public GetSsccByClienteConFiltrosHandler(
            IBaseRepository<Sscc> repository,
            IMapper mapper,
            ISsccDomainService ssccDomainService,
            IPaginationService paginationService)
        {
            _repository = repository;
            _mapper = mapper;
            _ssccDomainService = ssccDomainService;
            _paginationService = paginationService;
        }

        public async Task<ApiResponse<PaginationResponse<SsccResponse>>> Handle(
            GetSsccByClienteConFiltrosQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // Calcular paginación
                var (page, pageSize, skip) = _paginationService.CalculatePagination(request.Page, request.PageSize);

                // Crear query base con includes necesarios
                var baseQuery = _repository.AsQueryable()
                    .Include(s => s.IdPrefijoNavigation)
                    .AsNoTracking();

                // Obtener datos filtrados usando el domain service
                var (filteredItems, totalItems) = await _ssccDomainService.GetFilteredSsccsAsync(
                    request, baseQuery, cancellationToken);

                // Aplicar ordenamiento y paginación
                var pagedItems = filteredItems
                    .OrderByDescending(s => s.IdSscc)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(s => _mapper.Map<SsccResponse>(s))
                    .ToList();

                // Crear respuesta paginada
                var pagination = _paginationService.CreatePaginationResponse(
                    pagedItems, page, pageSize, totalItems,
                    "SSCC filtrados y paginados correctamente");

                return new ApiResponse<PaginationResponse<SsccResponse>>(
                    Id: Guid.NewGuid(),
                    Type: "PAGINATION",
                    Data: pagination,
                    Message: "SSCC encontrados correctamente",
                    Count: pagedItems.Count
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<PaginationResponse<SsccResponse>>.Error(
                    $"Error al obtener los SSCCs con filtros: {ex.Message}");
            }
        }
    }
}