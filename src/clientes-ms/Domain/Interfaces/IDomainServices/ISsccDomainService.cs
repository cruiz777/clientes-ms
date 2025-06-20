using clientes_ms.Application.Records.Response;

public interface ISsccDomainService
{
    // Construye todos los SSCC sin validarlos aún
    ApiResponse<List<string>> ConstruirCodigosSSCC(
        string prefijoEmpresa,
        byte indicador,
        int secuenciaInicio,
        int secuenciaFin);

    // Filtra cuáles ya existen en la base de datos
    Task<ApiResponse<List<string>>> FiltrarExistentesAsync(
        List<string> codigosGenerados,
        long idCliente,
        long idPrefijo);

    // Método actual que hace ambas cosas: genera y filtra
    Task<ApiResponse<List<string>>> GenerarCodigosSSCCAsync(
        long idPrefijo,
        long idCliente,
        string prefijoEmpresa,
        byte indicador,
        int secuenciaInicio,
        int secuenciaFin,
        int cantidad
        );
}
