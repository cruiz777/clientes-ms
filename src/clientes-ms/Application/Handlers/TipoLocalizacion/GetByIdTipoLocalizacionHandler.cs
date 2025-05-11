using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetTipoLocalizacionByIdHandler : IRequestHandler<GetTipoLocalizacionByIdQuery, ApiResponse<TipoLocalizacionResponse>>
{
    private readonly IBaseRepository<TipoLocalizacion> _repository;
    public GetTipoLocalizacionByIdHandler(IBaseRepository<TipoLocalizacion> repository) => _repository = repository;

    public async Task<ApiResponse<TipoLocalizacionResponse>> Handle(GetTipoLocalizacionByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<TipoLocalizacionResponse>(Guid.NewGuid(), "OBJECT", null, $"TipoLocalizacion with ID {request.Id} not found.");
            return new ApiResponse<TipoLocalizacionResponse>(Guid.NewGuid(), "OBJECT", new TipoLocalizacionResponse(e.IdTipoLocalizacion, e.Descripcion?.Trim() ??string.Empty,e.Estado??false), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoLocalizacionResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}