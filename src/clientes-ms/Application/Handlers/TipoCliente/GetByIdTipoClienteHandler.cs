using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class GetTipoClienteByIdHandler : IRequestHandler<GetTipoClienteByIdQuery, ApiResponse<TipoClienteResponse>>
{
    private readonly IBaseRepository<TipoCliente> _repository;
    public GetTipoClienteByIdHandler(IBaseRepository<TipoCliente> repository) => _repository = repository;

    public async Task<ApiResponse<TipoClienteResponse>> Handle(GetTipoClienteByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository
                .AsQueryable()
                .Include(tc => tc.IdEmpresaNavigation)
                .FirstOrDefaultAsync(tc => tc.IdTipoCliente == request.Id, cancellationToken);

            if (e == null)
                return new ApiResponse<TipoClienteResponse>(Guid.NewGuid(), "OBJECT", null, $"TipoCliente with ID {request.Id} not found.");

            var response = new TipoClienteResponse(
                id_tipo_cliente: e.IdTipoCliente,
                descripcion: e.Descripcion?.Trim() ?? string.Empty,
                cuenta: e.Cuenta?.Trim() ?? string.Empty,
                id_empresa: e.IdEmpresa ?? 1,
                estado: e.Estado ?? false,
                empresa: e.IdEmpresaNavigation?.Nombre?.Trim() ?? string.Empty
            );

            return new ApiResponse<TipoClienteResponse>(Guid.NewGuid(), "OBJECT", response, "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<TipoClienteResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
