using AutoMapper;
using clientes_ms.Application.Commands.Cupon;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers.Cupon;

public class CreateCuponHandler : IRequestHandler<CreateCuponCommand, ApiResponse<List<string>>>
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

    public async Task<ApiResponse<List<string>>> Handle(CreateCuponCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var r = request.Request;

            if (r.Cantidad <= 0)
                return ApiResponse<List<string>>.Error("La cantidad debe ser mayor a 0.");

            _cuponDomainService.ValidarFechas(r.FechaInicio, r.FechaCaducidad);

            var prefijoEntity = await _prefijoRepository.GetByIdAsync(r.IdPrefijo);
            if (prefijoEntity == null || string.IsNullOrWhiteSpace(prefijoEntity.Codpre))
                return ApiResponse<List<string>>.Error("El prefijo indicado no es válido.");

            string prefijo = prefijoEntity.Codpre.Trim();

            // Obtener serialInicio (desde request o calcular automáticamente)
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


            var codigosGenerados = new List<string>();
            var entidades = new List<Cupones>();
            var codigosAVerificar = new List<string>();

            for (int i = 0; i < r.Cantidad; i++)
            {
                int serial = serialInicio + i;
                string codigo = _cuponDomainService.GenerarCodigoCupon(prefijo, serial);
                codigosAVerificar.Add(codigo);
            }

            // Verificar duplicados en la base de datos
            var codigosExistentes = await _repository
                .AsQueryableNoTracking()
                .Where(c => codigosAVerificar.Contains(c.CodigoCupon))
                .Select(c => c.CodigoCupon)
                .ToListAsync(cancellationToken);

            if (codigosExistentes.Any())
            {
                return ApiResponse<List<string>>.Error(
                    $"Ya existen cupones con los siguientes códigos: {string.Join(", ", codigosExistentes)}");
            }

            // Crear cupones si no es previsualización
            for (int i = 0; i < r.Cantidad; i++)
            {
                int serial = serialInicio + i;
                string codigo = codigosAVerificar[i];
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

            if (!r.Previsualizar)
            {
                await _repository.AddRangeAsync(entidades);
                return new(Guid.NewGuid(), "SUCCESS", codigosGenerados, $"Se generaron y guardaron {codigosGenerados.Count} cupones.");
            }

            return new(Guid.NewGuid(), "PREVIEW", codigosGenerados, "Previsualización de cupones generada correctamente.");
        }
        catch (Exception ex)
        {
            return ApiResponse<List<string>>.Error($"Error al generar cupones: {ex.Message}");
        }
    }
}
