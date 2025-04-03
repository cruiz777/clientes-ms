using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetTipoClienteByIdHandler : IRequestHandler<GetTipoClienteByIdQuery, ApiResponse<TipoClienteResponse>>
{
    private readonly IBaseRepository<TipoCliente> _repository;
    public GetTipoClienteByIdHandler(IBaseRepository<TipoCliente> repository) => _repository = repository;

    public async Task<ApiResponse<TipoClienteResponse>> Handle(GetTipoClienteByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<TipoClienteResponse>(Guid.NewGuid(), "OBJECT", null, $"TipoCliente with ID {request.Id} not found.");
            return new ApiResponse<TipoClienteResponse>(Guid.NewGuid(), "OBJECT", new TipoClienteResponse(e.IdTipoCliente, e.Descripcion?.Trim() ??string.Empty,e.Cuenta?.Trim()?? string.Empty,  e.EmpresaCodigo??0), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoClienteResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}