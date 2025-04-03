using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetEstadoEmpresaByIdHandler : IRequestHandler<GetEstadoEmpresaByIdQuery, ApiResponse<EstadoEmpresaResponse>>
{
    private readonly IBaseRepository<EstadoEmpresa> _repository;
    public GetEstadoEmpresaByIdHandler(IBaseRepository<EstadoEmpresa> repository) => _repository = repository;

    public async Task<ApiResponse<EstadoEmpresaResponse>> Handle(GetEstadoEmpresaByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<EstadoEmpresaResponse>(Guid.NewGuid(), "OBJECT", null, $"EstadoEmpresa with ID {request.Id} not found.");
            return new ApiResponse<EstadoEmpresaResponse>(Guid.NewGuid(), "OBJECT", new EstadoEmpresaResponse(e.IdEstadoEmpresa, e.Nombre?.Trim() ?? string.Empty, e.Fecha??DateOnly.MinValue,e.EmpresaCodigo??0), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<EstadoEmpresaResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}