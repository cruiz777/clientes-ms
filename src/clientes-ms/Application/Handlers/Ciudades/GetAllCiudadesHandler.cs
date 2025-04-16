using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetAllCiudadesHandler : IRequestHandler<GetAllCiudadesQuery, ApiResponse<IEnumerable<CiudadesResponse>>>
{
    private readonly IBaseRepository<Ciudades> _repository;
    public GetAllCiudadesHandler(IBaseRepository<Ciudades> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<CiudadesResponse>>> Handle(GetAllCiudadesQuery request, CancellationToken cancellationToken)
    {
        //try
        //{
        //    var result = (await _repository.GetAllAsync()).Select(MapToResponse);
        //    return new ApiResponse<IEnumerable<CiudadesResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        //}
        //catch (Exception ex)
        //{
        //    return new ApiResponse<IEnumerable<CiudadesResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        //}
        try
        {
            var ciudades = await _repository
                .AsQueryable()
                .Include(ci => ci.IdCantonNavigation)
                    .ThenInclude(c => c.IdProvinciaNavigation)
                .Select(ci => new CiudadesResponse
                {
                    IdCiudad = ci.IdCiudad,
                    Codigo = ci.Referencia,
                    Ciudad = ci.Nombre,
                    Canton = ci.IdCantonNavigation.Nombre,
                    Provincia = ci.IdCantonNavigation.IdProvinciaNavigation.Nombre
                })
                .ToListAsync(cancellationToken);

            return new ApiResponse<IEnumerable<CiudadesResponse>>(
                Guid.NewGuid(),
                "LIST",
                ciudades,
                "Ciudades retrieved successfully."
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<CiudadesResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error retrieving ciudades: {ex.Message}"
            );
        }
    }

    //private static CiudadesResponse MapToResponse(Ciudades e) => new(e.IdCiudad, e.Referencia?.Trim() ?? string.Empty, e.Nombre?.Trim() ?? string.Empty,e.IdCiudad);
    private static CiudadesResponse MapToResponse(Ciudades e) => new CiudadesResponse
    {
        IdCiudad = e.IdCiudad,
        Codigo = e.Referencia?.Trim() ?? string.Empty,
        Ciudad = e.Nombre?.Trim() ?? string.Empty,
        Canton = e.IdCantonNavigation?.Nombre ?? string.Empty,
        Provincia = e.IdCantonNavigation?.IdProvinciaNavigation?.Nombre ?? string.Empty
    };
}