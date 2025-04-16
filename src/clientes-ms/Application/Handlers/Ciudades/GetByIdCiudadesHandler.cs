using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetCiudadesByIdHandler : IRequestHandler<GetCiudadesByIdQuery, ApiResponse<CiudadesResponse>>
{
    private readonly IBaseRepository<Ciudades> _repository;

    public GetCiudadesByIdHandler(IBaseRepository<Ciudades> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<CiudadesResponse>> Handle(GetCiudadesByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var ciudad = await _repository
                .AsQueryable()
                .Include(ci => ci.IdCantonNavigation)
                    .ThenInclude(c => c.IdProvinciaNavigation)
                .FirstOrDefaultAsync(ci => ci.IdCiudad == request.Id, cancellationToken);

            if (ciudad == null)
            {
                return new ApiResponse<CiudadesResponse>(
                    Guid.NewGuid(), "OBJECT", null, $"Ciudad con ID {request.Id} no encontrada.");
            }

            var response = new CiudadesResponse
            {
                IdCiudad = ciudad.IdCiudad,
                Codigo = ciudad.Referencia?.Trim() ?? string.Empty,
                Ciudad = ciudad.Nombre?.Trim() ?? string.Empty,
                Canton = ciudad.IdCantonNavigation?.Nombre?.Trim() ?? string.Empty,
                Provincia = ciudad.IdCantonNavigation?.IdProvinciaNavigation?.Nombre?.Trim() ?? string.Empty
            };

            return new ApiResponse<CiudadesResponse>(
                Guid.NewGuid(), "OBJECT", response, "Ciudad obtenida correctamente.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<CiudadesResponse>(
                Guid.NewGuid(), "ERROR", null, $"Error al obtener ciudad: {ex.Message}");
        }
    }

}


