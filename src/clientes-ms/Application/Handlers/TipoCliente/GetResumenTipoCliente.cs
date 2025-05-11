using clientes_ms.Application.Records.Response;
using Microsoft.EntityFrameworkCore;
using MediatR;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using System.Linq;

public class GetResumenTipoClienteHandler : IRequestHandler<GetTipoClienteByResumen, ApiResponse<IEnumerable<TipoClienteResponse>>>
{
    private readonly IBaseRepository<TipoCliente> _repository;

    public GetResumenTipoClienteHandler(IBaseRepository<TipoCliente> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<TipoClienteResponse>>> Handle(GetTipoClienteByResumen request, CancellationToken cancellationToken)
    {
        try
        {
            var tipoclientes = await _repository
                .AsQueryable()
                .Include(e => e.IdEmpresaNavigation)
                .ToListAsync(cancellationToken);

            var result = tipoclientes.Select(t => new TipoClienteResponse(
                id_tipo_cliente: t.IdTipoCliente,
                descripcion: t.Descripcion ?? string.Empty,
                cuenta: t.Cuenta ?? string.Empty,
                id_empresa: t.IdEmpresa ?? 1,
                estado: t.Estado ?? false,
                empresa: t.IdEmpresaNavigation?.Nombre ?? string.Empty
            )).ToList();

            return new ApiResponse<IEnumerable<TipoClienteResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                $"Se encontraron {result.Count} tipo(s) de cliente.",
                result.Count
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TipoClienteResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al obtener los tipos de cliente: {ex.Message}"
            );
        }
    }
}
