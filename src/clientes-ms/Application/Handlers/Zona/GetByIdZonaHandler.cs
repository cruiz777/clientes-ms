using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetZonaByIdHandler : IRequestHandler<GetZonaByIdQuery, ApiResponse<ZonaResponse>>
{
    private readonly IBaseRepository<Zona> _repository;
    public GetZonaByIdHandler(IBaseRepository<Zona> repository) => _repository = repository;

    public async Task<ApiResponse<ZonaResponse>> Handle(GetZonaByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<ZonaResponse>(Guid.NewGuid(), "OBJECT", null, $"Zona with ID {request.Id} not found.");
            return new ApiResponse<ZonaResponse>(Guid.NewGuid(), "OBJECT", new ZonaResponse(e.IdZona, e.Referencia?.Trim() ?? string.Empty,e.Nombre?.Trim() ?? string.Empty,e.Numero?.Trim()?? string.Empty,e.EmpresaCodigo ??0), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<ZonaResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}