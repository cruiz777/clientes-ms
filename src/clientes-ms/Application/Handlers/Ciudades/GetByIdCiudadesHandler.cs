using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetCiudadesByIdHandler : IRequestHandler<GetCiudadesByIdQuery, ApiResponse<CiudadesResponse>>
{
    private readonly IBaseRepository<Ciudades> _repository;
    public GetCiudadesByIdHandler(IBaseRepository<Ciudades> repository) => _repository = repository;

    public async Task<ApiResponse<CiudadesResponse>> Handle(GetCiudadesByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<CiudadesResponse>(Guid.NewGuid(), "OBJECT", null, $"Ciudades with ID {request.Id} not found.");
            return new ApiResponse<CiudadesResponse>(Guid.NewGuid(), "OBJECT", new CiudadesResponse(e.IdCiudad, e.Referencia?.Trim() ?? string.Empty, e.Nombre?.Trim() ?? string.Empty,e.IdCanton), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<CiudadesResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}