using clientes_ms.Application.Records.Response;
using MediatR;

public class GetHistorialClienteByCodigoClienteQuery : IRequest<ApiResponse<IEnumerable<HistorialClienteResponse>>>
{
    public long ClientesCodigo { get; set; }
    public string? TipoAccion { get; set; }
    public string? Tabla { get; set; }

    public long IdEmpresa { get; set; }
}
