// ✅ Response nueva (sin Anio/Mes)
namespace clientes_ms.Application.Records.Response
{
    public record ResumenTipoClienteDiagnosticoTotal(
        int Total
    );

    public record ResumenTipoClienteTotalResponse(
        List<TipoClienteConteoResponse> TotalPorTipo,
        ResumenTipoClienteDiagnosticoTotal Diagnostico
    );
}
