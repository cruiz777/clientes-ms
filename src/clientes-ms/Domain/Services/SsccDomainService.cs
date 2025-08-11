using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Common;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Specifications;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
    string codpre,
    byte indicador,
    int secuenciaInicio,
    int secuenciaFin,
    int cantidad)
    {
        if (indicador > 9)
            return Error("El indicador debe estar entre 0 y 9.");

        if (secuenciaInicio < 0 || secuenciaFin < secuenciaInicio)
            return Error("El rango de secuencia es inválido.");

        var codigoPais = await _parametroDomainService.ObtenerValorParametroAsync("CODIGO_ECUADOR", "dev");
        if (string.IsNullOrWhiteSpace(codigoPais))
            return Error("No se pudo obtener el código de país desde parámetros.");

        string prefijoBase = $"{indicador}{codigoPais}{codpre}";
        int longitudSerial = 17 - prefijoBase.Length;

        if (longitudSerial < 1 || longitudSerial > 8)
            return Error("Prefijo compuesto demasiado largo. Solo se permiten seriales entre 1 y 8 dígitos.");

        var todosCodigos = Enumerable.Range(secuenciaInicio, secuenciaFin - secuenciaInicio + 1)
            .Select(i =>
            {
                string serial = i.ToString().PadLeft(longitudSerial, '0');
                string baseCode = prefijoBase + serial;
                string sscc = baseCode + DigitoVerificadorHelper.CalcularModulo10(baseCode);
                return sscc;
            }).ToList();

        var existentes = await _repository.GetListByConditionAsync(x =>
            x.IdCliente == idCliente &&
            x.IdPrefijo == idPrefijo &&
            todosCodigos.Contains(x.SsccCompleto!)
        );

        if (existentes.Any())
        {
            return Error($"Todos o algunos de los códigos SSCC entre la secuencia {secuenciaInicio} y {secuenciaFin} ya existen para el prefijo {codpre}.");
        }

        if (todosCodigos.Count != cantidad)
        {
            return Error("La cantidad de códigos generados no coincide con el rango de secuencias definido.");
        }

        return new(Guid.NewGuid(), "SUCCESS", todosCodigos, "SSCC generados correctamente", todosCodigos.Count);
    }


    public ApiResponse<List<string>> ConstruirCodigosSSCC(
    string codigoPais,
    string codpre,
    byte indicador,
    int secuenciaInicio,
    int secuenciaFin)
    {
        if (indicador > 9)
            return Error("El indicador debe estar entre 0 y 9.");

        string prefijoBase = $"{indicador}{codigoPais}{codpre}";
        int longitudSerial = 17 - prefijoBase.Length;

        if (longitudSerial < 1 || longitudSerial > 8)
            return Error("Prefijo compuesto demasiado largo. Solo se permiten seriales entre 1 y 8 dígitos.");

        var resultado = Enumerable.Range(secuenciaInicio, secuenciaFin - secuenciaInicio + 1)
            .Select(i =>
            {
                string serial = i.ToString().PadLeft(longitudSerial, '0');
                string baseCode = prefijoBase + serial;
                string sscc = baseCode + DigitoVerificadorHelper.CalcularModulo10(baseCode);
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

    public Task<string?> ObtenerCodigoPaisEcuador()
    {
        return _parametroDomainService.ObtenerValorParametroAsync("CODIGO_ECUADOR", "dev");
    }

    private static ApiResponse<List<string>> Error(string mensaje) =>
        new(Guid.NewGuid(), "ERROR", null, mensaje);

    public Expression<Func<Sscc, bool>> BuildFilterCriteria(GetSsccByClienteConFiltrosQuery request)
    {
        var specification = new SsccFilterSpecification(request);
        return specification.Criteria;
    }

    public bool HasSerialFilters(GetSsccByClienteConFiltrosQuery request)
    {
        return !string.IsNullOrWhiteSpace(request.SerialDesde) ||
               !string.IsNullOrWhiteSpace(request.SerialHasta);
    }

    public IEnumerable<Sscc> ApplySerialFilters(IEnumerable<Sscc> ssccList, GetSsccByClienteConFiltrosQuery request)
    {
        var result = ssccList.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(request.SerialDesde) &&
            int.TryParse(request.SerialDesde, out var serialDesdeInt))
        {
            result = result.Where(s => ExtractSerialFromSscc(s) >= serialDesdeInt);
        }

        if (!string.IsNullOrWhiteSpace(request.SerialHasta) &&
            int.TryParse(request.SerialHasta, out var serialHastaInt))
        {
            result = result.Where(s => ExtractSerialFromSscc(s) <= serialHastaInt);
        }

        return result;
    }

    public int ExtractSerialFromSscc(Sscc sscc)
    {
        if (string.IsNullOrWhiteSpace(sscc.SsccCompleto) ||
            sscc.SsccCompleto.Length != 18 ||
            sscc.IdPrefijoNavigation?.Codpre == null)
            return 0;

        var prefixCode = sscc.IdPrefijoNavigation.Codpre;
        var prefixLength = prefixCode.Length;

        try
        {
            return prefixLength switch
            {
                5 => int.Parse(sscc.SsccCompleto.Substring(9, 8)),   // 9 dígitos de serial
                6 => int.Parse(sscc.SsccCompleto.Substring(10, 7)),  // 8 dígitos de serial
                7 => int.Parse(sscc.SsccCompleto.Substring(11, 6)),  // 7 dígitos de serial
                8 => int.Parse(sscc.SsccCompleto.Substring(12, 5)),  // 6 dígitos de serial
                _ => 0
            };
        }
        catch
        {
            return 0;
        }
    }

    public async Task<(IEnumerable<Sscc> items, int totalCount)> GetFilteredSsccsAsync(
        GetSsccByClienteConFiltrosQuery request,
        IQueryable<Sscc> baseQuery,
        CancellationToken cancellationToken)
    {
        var filterCriteria = BuildFilterCriteria(request);
        var filteredQuery = baseQuery.Where(filterCriteria);

        if (HasSerialFilters(request))
        {
            // Para filtros de serial, necesitamos procesar en memoria
            var candidatos = await filteredQuery.ToListAsync(cancellationToken);
            var filteredCandidatos = ApplySerialFilters(candidatos, request).ToList();

            return (filteredCandidatos, filteredCandidatos.Count);
        }
        else
        {
            // Sin filtros de serial, podemos usar la base de datos directamente
            var totalCount = await filteredQuery.CountAsync(cancellationToken);
            var items = await filteredQuery.ToListAsync(cancellationToken);

            return (items, totalCount);
        }
    }
}
