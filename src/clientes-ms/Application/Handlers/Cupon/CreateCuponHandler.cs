using AutoMapper;
using clientes_ms.Application.Commands.Cupon;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers.Cupon;

public class CreateCuponHandler : IRequestHandler<CreateCuponCommand, ApiResponse<CreateCuponResponse>>
{
    private readonly IBaseRepository<Cupones> _repository;
    private readonly IBaseRepository<Prefijos> _prefijoRepository;
    private readonly ICuponDomainService _cuponDomainService;
    private readonly IMapper _mapper;

    public CreateCuponHandler(
        IBaseRepository<Cupones> repository,
        IBaseRepository<Prefijos> prefijoRepository,
        ICuponDomainService cuponDomainService,
        IMapper mapper)
    {
        _repository = repository;
        _prefijoRepository = prefijoRepository;
        _cuponDomainService = cuponDomainService;
        _mapper = mapper;
    }

    public async Task<ApiResponse<CreateCuponResponse>> Handle(CreateCuponCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var r = request.Request;

            if (r.Cantidad <= 0)
                return ApiResponse<CreateCuponResponse>.Error("La cantidad debe ser mayor a 0.");

            _cuponDomainService.ValidarFechas(r.FechaInicio, r.FechaCaducidad);

            var prefijoEntity = await _prefijoRepository.GetByIdAsync(r.IdPrefijo);
            if (prefijoEntity == null || string.IsNullOrWhiteSpace(prefijoEntity.Codpre))
                return ApiResponse<CreateCuponResponse>.Error("El prefijo indicado no es válido.");

            string prefijo = prefijoEntity.Codpre.Trim();

            int serialInicio;
            if (r.SerialInicio.HasValue && r.SerialInicio > 0)
            {
                serialInicio = r.SerialInicio.Value;
            }
            else
            {
                var maxSerial = await _repository
                    .AsQueryableNoTracking()
                    .Where(c => c.IdPrefijo == r.IdPrefijo && c.Serial.HasValue)
                    .MaxAsync(c => (int?)c.Serial, cancellationToken) ?? 0;

                serialInicio = maxSerial + 1;
            }

            var codigosAVerificar = new List<(string Codigo, int Serial)>();
            for (int i = 0; i < r.Cantidad; i++)
            {
                int serial = serialInicio + i;
                string codigo = _cuponDomainService.GenerarCodigoCupon(prefijo, serial);
                codigosAVerificar.Add((codigo, serial));
            }

            var codigosGenerados = new List<string>();
            var entidades = new List<Cupones>();

            var codigosStr = codigosAVerificar.Select(c => c.Codigo).ToList();

            var codigosExistentes = await _repository
                .AsQueryableNoTracking()
                .Where(c => codigosStr.Contains(c.CodigoCupon))
                .Select(c => c.CodigoCupon)
                .ToListAsync(cancellationToken);

            var codigosNoExistentes = codigosAVerificar
                .Where(c => !codigosExistentes.Contains(c.Codigo))
                .ToList();

            foreach (var (codigo, serial) in codigosNoExistentes)
            {
                codigosGenerados.Add(codigo);

                if (!r.Previsualizar)
                {
                    var cupon = _mapper.Map<Cupones>(r);
                    cupon.Serial = serial;
                    cupon.CodigoCupon = codigo;
                    cupon.Estado = true;
                    cupon.FechaCreacion = DateTime.Now;
                    entidades.Add(cupon);
                }
            }

            if (!codigosGenerados.Any())
            {
                return ApiResponse<CreateCuponResponse>.Error("Todos los códigos generados ya existen. No se creó ningún cupón.");
            }

            var response = new CreateCuponResponse
            {
                CuponesGenerados = codigosGenerados,
                CuponesDuplicados = codigosExistentes
            };

            if (!r.Previsualizar)
            {
                await _repository.AddRangeAsync(entidades);
                return new(Guid.NewGuid(), "PARTIAL_SUCCESS", response,
                    codigosExistentes.Any()
                        ? $"Se guardaron {codigosGenerados.Count} cupones. {codigosExistentes.Count} ya existían."
                        : $"Se generaron y guardaron {codigosGenerados.Count} cupones.");
            }

            return new(Guid.NewGuid(), "PREVIEW", response,
                codigosExistentes.Any()
                    ? $"Previsualización generada. Se omitieron {codigosExistentes.Count} códigos ya existentes."
                    : "Previsualización de cupones generada correctamente.");
        }
        catch (Exception ex)
        {
            return ApiResponse<CreateCuponResponse>.Error($"Error al generar cupones: {ex.Message}");
        }
    }
}
