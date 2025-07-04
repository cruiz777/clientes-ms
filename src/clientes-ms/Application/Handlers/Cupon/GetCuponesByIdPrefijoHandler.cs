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

public class GetCuponesByIdPrefijoHandler : IRequestHandler<GetCuponesByIdPrefijoQuery, ApiResponse<List<CuponResponse>>>
{
    private readonly IBaseRepository<Cupones> _repository;
    private readonly IMapper _mapper;
    private readonly ICuponDomainService _cuponDomainService;

    public GetCuponesByIdPrefijoHandler(
        IBaseRepository<Cupones> repository,
        IMapper mapper,
        ICuponDomainService cuponDomainService)
    {
        _repository = repository;
        _mapper = mapper;
        _cuponDomainService = cuponDomainService;
    }

    public async Task<ApiResponse<List<CuponResponse>>> Handle(GetCuponesByIdPrefijoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var cupones = await _repository.AsQueryable()
                .Where(c => c.IdPrefijo == request.IdPrefijo)
                .ToListAsync(cancellationToken);

            foreach (var cupon in cupones)
            {
                bool vigente = _cuponDomainService.EsCuponVigente(cupon.FechaInicio, cupon.FechaCaducidad);

                if (!vigente && cupon.Estado)
                {
                    cupon.Estado = false;
                    await _repository.UpdateAsync(cupon.IdCupon, cupon);
                }
            }

            var response = cupones
                .AsQueryable()
                .ProjectTo<CuponResponse>(_mapper.ConfigurationProvider)
                .ToList();

            return new ApiResponse<List<CuponResponse>>(
                Id: Guid.NewGuid(),
                Type: "LIST",
                Data: response,
                Message: "Cupones encontrados correctamente",
                Count: response.Count
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<CuponResponse>>.Error($"Error al obtener los cupones por prefijo: {ex.Message}");
        }
    }
}
