using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Domain.Services;

public class SsccDomainService : ISsccDomainService
{
    private readonly IBaseRepository<Sscc> _repository;
    private readonly IParametroDomainService _parametroDomainService;

    public SsccDomainService(
        IBaseRepository<Sscc> repository,
        IParametroDomainService parametroDomainService)
    {
        _repository = repository;
        _parametroDomainService = parametroDomainService;
    }

    public async Task<ApiResponse<List<string>>> GenerarCodigosSSCCAsync(
    long idPrefijo,
    long idCliente,
    string prefijoEmpresa,
    byte indicador,
    int secuenciaInicio,
    int secuenciaFin,
    int cantidad)
    {
        if (indicador > 9)
            return Error("El indicador debe estar entre 0 y 9.");

        if (secuenciaInicio < 1 || secuenciaFin < secuenciaInicio)
            return Error("El rango de secuencia es inválido.");

        var codigoPais = await _parametroDomainService.ObtenerValorParametroAsync("CODIGO_ECUADOR", "dev");
        if (string.IsNullOrWhiteSpace(codigoPais))
            return Error("No se pudo obtener el código de país desde parámetros.");

        string prefijoBase = $"{indicador}{prefijoEmpresa}";
        int longitudSerial = 17 - prefijoBase.Length;

        if (longitudSerial < 1 || longitudSerial > 8)
            return Error("Prefijo demasiado largo. Solo se permiten seriales entre 1 y 8 dígitos.");

        // Construcción previa de todos los códigos
        var todosCodigos = Enumerable.Range(secuenciaInicio, secuenciaFin - secuenciaInicio + 1)
            .Select(i =>
            {
                string serial = i.ToString().PadLeft(longitudSerial, '0');
                string baseCode = prefijoBase + serial;
                string sscc = baseCode + CalcularDigitoVerificadorMod10(baseCode);
                return sscc;
            }).ToList();

        // Revisión masiva de duplicados
        var existentes = await _repository.GetListByConditionAsync(x =>
            x.IdCliente == idCliente &&
            x.IdPrefijo == idPrefijo &&
            todosCodigos.Contains(x.SsccCompleto!)
        );

        if (existentes.Any())
        {
            return Error($"Todos o algunos de los códigos SSCC entre la secuencia {secuenciaInicio} y {secuenciaFin} ya existen para el prefijo {prefijoEmpresa}.");
        }

        if (todosCodigos.Count != cantidad)
        {
            return Error("La cantidad de códigos generados no coincide con el rango de secuencias definido.");
        }

        return new(Guid.NewGuid(), "SUCCESS", todosCodigos, "SSCC generados correctamente", todosCodigos.Count);
    }


    public ApiResponse<List<string>> ConstruirCodigosSSCC(
        string prefijoEmpresa,
        byte indicador,
        int secuenciaInicio,
        int secuenciaFin)
    {
        if (indicador > 9)
            return Error("El indicador debe estar entre 0 y 9.");

        string prefijoBase = $"{indicador}{prefijoEmpresa}";
        int longitudSerial = 17 - prefijoBase.Length;

        if (longitudSerial < 1 || longitudSerial > 8)
            return Error("Prefijo demasiado largo. Solo se permiten seriales entre 1 y 8 dígitos.");

        var resultado = Enumerable.Range(secuenciaInicio, secuenciaFin - secuenciaInicio + 1)
            .Select(i =>
            {
                string serial = i.ToString().PadLeft(longitudSerial, '0');
                string baseCode = prefijoBase + serial;
                string sscc = baseCode + CalcularDigitoVerificadorMod10(baseCode);
                return sscc;
            })
            .ToList();

        return new(Guid.NewGuid(), "SUCCESS", resultado, "SSCC generados correctamente", resultado.Count);
    }

    public async Task<ApiResponse<List<string>>> FiltrarExistentesAsync(
        List<string> codigosGenerados,
        long idCliente,
        long idPrefijo)
    {
        var existentes = await _repository.GetListByConditionAsync(x =>
            x.IdCliente == idCliente &&
            x.IdPrefijo == idPrefijo &&
            codigosGenerados.Contains(x.SsccCompleto!)
        );

        var codigosExistentes = existentes.Select(x => x.SsccCompleto!).ToHashSet();
        var disponibles = codigosGenerados.Where(c => !codigosExistentes.Contains(c)).ToList();

        return new(Guid.NewGuid(), "SUCCESS", disponibles, "Códigos no registrados", disponibles.Count);
    }

    private static char CalcularDigitoVerificadorMod10(string base17)
    {
        int suma = 0;
        bool multiplicarPorTres = true;

        for (int i = base17.Length - 1; i >= 0; i--)
        {
            int digito = base17[i] - '0';
            suma += multiplicarPorTres ? digito * 3 : digito;
            multiplicarPorTres = !multiplicarPorTres;
        }

        int modulo = suma % 10;
        int resultado = modulo == 0 ? 0 : 10 - modulo;

        return resultado.ToString()[0];
    }

    private static ApiResponse<List<string>> Error(string mensaje) =>
        new(Guid.NewGuid(), "ERROR", null, mensaje);
}
