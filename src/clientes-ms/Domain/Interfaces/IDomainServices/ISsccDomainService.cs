using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using System.Linq.Expressions;

public interface ISsccDomainService
{
    // Construye todos los SSCC sin validarlos aún
    ApiResponse<List<string>> ConstruirCodigosSSCC(
        string codigoPais,
        string codpre,
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
        string codpre,
        byte indicador,
        int secuenciaInicio,
        int secuenciaFin,
        int cantidad
        );
    Task<string?> ObtenerCodigoPaisEcuador();
    Expression<Func<Sscc, bool>> BuildFilterCriteria(GetSsccByClienteConFiltrosQuery request);
    bool HasSerialFilters(GetSsccByClienteConFiltrosQuery request);
    IEnumerable<Sscc> ApplySerialFilters(IEnumerable<Sscc> ssccList, GetSsccByClienteConFiltrosQuery request);
    int ExtractSerialFromSscc(Sscc sscc);
    Task<(IEnumerable<Sscc> items, int totalCount)> GetFilteredSsccsAsync(
        GetSsccByClienteConFiltrosQuery request,
        IQueryable<Sscc> baseQuery,
        CancellationToken cancellationToken);
}
