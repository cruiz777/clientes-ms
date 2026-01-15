namespace clientes_ms.Application.Records.Response
{
    public record TipoClienteConteoResponse(
        long? IdTipoCliente,
        string Descripcion,
        int Cantidad
    );

    public record ResumenTipoClienteDiagnostico(
        int TotalAnio,
        int TotalMes
    );

    public record ResumenTipoClienteAnioMesResponse(
        int Anio,
        int Mes,
        List<TipoClienteConteoResponse> AcumuladoAnio,
        List<TipoClienteConteoResponse> AcumuladoMes,
        ResumenTipoClienteDiagnostico Diagnostico
    );
}
