using clientes_ms.Application.Queries.Gln;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.Glns
{
    public class ValidarSecuenciaDisponibleHandler : IRequestHandler<ValidarSecuenciaDisponibleQuery, ApiResponse<bool>>
    {
        private readonly IBaseRepository<Gln> _repository;

        public ValidarSecuenciaDisponibleHandler(IBaseRepository<Gln> repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<bool>> Handle(ValidarSecuenciaDisponibleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Generar el GLN completo con la secuencia propuesta
                var glnPropuesto = GenerarGlnCompleto(request.CodigoPais, request.Prefijo, request.Secuencia);

                // ✅ Usar ExistsAsync que ya existe en tu BaseRepository
                var existe = await _repository.ExistsAsync(g => g.Gln1 == glnPropuesto);

                if (existe)
                {
                    return new ApiResponse<bool>(
                        Guid.NewGuid(),
                        "CONFLICT",
                        false,
                        $"La secuencia {request.Secuencia} ya está en uso (GLN: {glnPropuesto})"
                    );
                }

                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    true,
                    $"Secuencia {request.Secuencia} disponible"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "ERROR",
                    false,
                    $"Error al validar secuencia: {ex.Message}"
                );
            }
        }

        private string GenerarGlnCompleto(string codigoPais, string prefijo, int secuencia)
        {
            var longitudSecuencia = 12 - (codigoPais.Length + prefijo.Length);
            var secuenciaTexto = secuencia.ToString().PadLeft(longitudSecuencia, '0');
            var glnSinVerificador = $"{codigoPais}{prefijo}{secuenciaTexto}";
            var digitoVerificador = CalcularDigitoVerificador(glnSinVerificador);
            return $"{glnSinVerificador}{digitoVerificador}";
        }

        private int CalcularDigitoVerificador(string numero)
        {
            int suma = 0;
            int longitud = numero.Length;

            for (int i = 0; i < longitud; i++)
            {
                int digito = int.Parse(numero[longitud - 1 - i].ToString());
                suma += i % 2 == 0 ? digito * 3 : digito;
            }

            int modulo = suma % 10;
            return modulo == 0 ? 0 : 10 - modulo;
        }
    }
}