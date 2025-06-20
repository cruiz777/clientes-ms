using AutoMapper;
using clientes_ms.Application.Commands.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers.Ssccs;

public class CreateSsccHandler : IRequestHandler<CreateSsccCommand, ApiResponse<List<string>>>
{
    private readonly IBaseRepository<Sscc> _repository;
    private readonly IBaseRepository<Prefijos> _prefijoRepository;
    private readonly ISsccDomainService _ssccDomainService;
    private readonly IMapper _mapper;

    public CreateSsccHandler(
        IBaseRepository<Sscc> repository,
        IBaseRepository<Prefijos> prefijoRepository,
        ISsccDomainService ssccDomainService,
        IMapper mapper)
    {
        _repository = repository;
        _prefijoRepository = prefijoRepository;
        _ssccDomainService = ssccDomainService;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<string>>> Handle(CreateSsccCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var r = request.Request;

            if (r.CantidadCodigos is null || r.CantidadCodigos <= 0)
                return ApiResponse<List<string>>.Error("Debe especificar una cantidad válida de códigos a generar.");

            // Obtener el prefijo
            var prefijoEntity = await _prefijoRepository.GetByIdAsync(r.IdPrefijo);
            if (prefijoEntity is null)
                return ApiResponse<List<string>>.Error("El prefijo indicado no existe.");

            string prefijoEmpresa = prefijoEntity.Prefijosgs1?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(prefijoEmpresa))
                return ApiResponse<List<string>>.Error("El prefijo GS1 no está definido correctamente.");

            // Calcular secuencia de inicio si no se envía
            int secuenciaInicio = r.SecuenciaInicio ?? await ObtenerSiguienteSecuenciaDisponible(r.IdPrefijo, r.IdCliente);
            int secuenciaFin = secuenciaInicio + r.CantidadCodigos.Value - 1;

            if (secuenciaFin < secuenciaInicio)
                return ApiResponse<List<string>>.Error("La secuencia final no puede ser menor que la inicial.");

            // Generar códigos SSCC
            var codigosGenerados = await _ssccDomainService.GenerarCodigosSSCCAsync(
                idPrefijo: r.IdPrefijo,
                idCliente: r.IdCliente,
                prefijoEmpresa: prefijoEmpresa,
                indicador: r.Indicador,
                secuenciaInicio: secuenciaInicio,
                secuenciaFin: secuenciaFin,
                cantidad: r.CantidadCodigos.Value
            );

            if (codigosGenerados.Type == "ERROR")
                return codigosGenerados;

            if (codigosGenerados.Data is null || !codigosGenerados.Data.Any())
                return ApiResponse<List<string>>.Error("No se generaron nuevos códigos SSCC.");

            // Mapear y guardar entidades
            var entidades = codigosGenerados.Data.Select(ssccCompleto =>
            {
                var base17 = ssccCompleto[..17];
                var digito = ssccCompleto[^1];
                var serial = base17.Substring(prefijoEmpresa.Length + 4);

                var entity = _mapper.Map<Sscc>(r);
                entity.Serial = serial;
                entity.DigitoControl = digito.ToString();
                entity.SsccCompleto = ssccCompleto;
                entity.SecuenciaInicio = secuenciaInicio;
                entity.SecuenciaFin = secuenciaFin;
                entity.TotalGenerado = r.CantidadCodigos;
                return entity;
            }).ToList();

            await _repository.AddRangeAsync(entidades); //Guarda en el rango de los codigos que vengan
            var listaSscc = entidades.Select(e => e.SsccCompleto!).ToList();

            return new(Guid.NewGuid(), "SUCCESS", listaSscc, $"Se generaron y guardaron {listaSscc.Count} códigos SSCC.");
        }
        catch (Exception ex)
        {
            return ApiResponse<List<string>>.Error($"Error inesperado: {ex.Message}");
        }
    }

    private async Task<int> ObtenerSiguienteSecuenciaDisponible(long idPrefijo, long idCliente)
    {
        var ultimoSscc = await _repository.AsQueryable()
            .Where(x => x.IdPrefijo == idPrefijo && x.IdCliente == idCliente)
            .OrderByDescending(x => x.SecuenciaFin)
            .FirstOrDefaultAsync();

        return (ultimoSscc?.SecuenciaFin ?? 0) + 1;
    }
}
