using clientes_ms.Application.Commands.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GenerateSsccHandler : IRequestHandler<GenerateSsccCommand, ApiResponse<List<string>>>
{
    private readonly IBaseRepository<Prefijos> _prefijoRepository;
    private readonly IBaseRepository<Sscc> _ssccRepository;
    private readonly ISsccDomainService _ssccDomainService;

    public GenerateSsccHandler(
        IBaseRepository<Prefijos> prefijoRepository,
        IBaseRepository<Sscc> ssccRepository,
        ISsccDomainService ssccDomainService)
    {
        _prefijoRepository = prefijoRepository;
        _ssccRepository = ssccRepository;
        _ssccDomainService = ssccDomainService;
    }

    public async Task<ApiResponse<List<string>>> Handle(GenerateSsccCommand request, CancellationToken cancellationToken)
    {
        var r = request.Request;

        if (r.CantidadCodigos <= 0)
            return ApiResponse<List<string>>.Error("La cantidad de códigos a generar debe ser mayor a cero.");

        // Obtener el prefijo
        var prefijoEntity = await _prefijoRepository.GetByIdAsync(r.IdPrefijo);
        if (prefijoEntity is null)
            return ApiResponse<List<string>>.Error($"Prefijo con ID {r.IdPrefijo} no encontrado.");

        // Obtener la secuencia de inicio si no se proporciona
        int secuenciaInicio = r.SecuenciaInicio ?? await ObtenerSiguienteSecuenciaDisponible(r.IdPrefijo, r.IdCliente);
        int secuenciaFin = secuenciaInicio + r.CantidadCodigos - 1;

        if (secuenciaInicio < 1 || secuenciaFin < secuenciaInicio)
            return ApiResponse<List<string>>.Error("El rango de secuencia es inválido.");
        string codpre = prefijoEntity.Codpre?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(codpre))
            return ApiResponse<List<string>>.Error("El código de prefijo no está definido correctamente.");
        var codigoPais = await _ssccDomainService.ObtenerCodigoPaisEcuador(); // puedes exponerlo como método si deseas
        if (string.IsNullOrWhiteSpace(codigoPais))
            return ApiResponse<List<string>>.Error("No se pudo obtener el código de país.");

        // Generar todos los códigos posibles del rango
        var todosCodigos = _ssccDomainService.ConstruirCodigosSSCC(
            codigoPais: codigoPais,
            codpre: codpre,
            indicador: r.Indicador,
            secuenciaInicio: secuenciaInicio,
            secuenciaFin: secuenciaFin
        );


        if (todosCodigos.Type == "ERROR" || todosCodigos.Data is null)
            return todosCodigos;

        // Filtrar los que ya existan
        var filtrados = await _ssccDomainService.FiltrarExistentesAsync(
            todosCodigos.Data,
            idCliente: r.IdCliente,
            idPrefijo: r.IdPrefijo
        );

        if (filtrados.Data is null || !filtrados.Data.Any())
        {
            return ApiResponse<List<string>>.Error(
                $"Todos los códigos entre la secuencia {secuenciaInicio} y {secuenciaFin} ya han sido generados previamente para el prefijo {codpre}."
            );
        }

        return new(
            Guid.NewGuid(),
            "SUCCESS",
            filtrados.Data,
            $"Se generaron {filtrados.Data.Count} códigos SSCC con prefijo compuesto {codigoPais}{codpre}{r.Indicador} (vista previa sin guardar).",

            filtrados.Data.Count
        );
    }

    private async Task<int> ObtenerSiguienteSecuenciaDisponible(long idPrefijo, long idCliente)
    {
        var ultimoSscc = await _ssccRepository.AsQueryable()
            .Where(x => x.IdPrefijo == idPrefijo && x.IdCliente == idCliente)
            .OrderByDescending(x => x.SecuenciaFin)
            .FirstOrDefaultAsync();

        return (ultimoSscc?.SecuenciaFin ?? 0) + 1;
    }
}
