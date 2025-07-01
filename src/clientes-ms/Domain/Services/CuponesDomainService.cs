using clientes_ms.Domain.Common;
using clientes_ms.Domain.Interfaces.IDomainServices;
using clientes_ms.Domain.Services;

namespace clientes_ms.Infrastructure.Services;

public class CuponDomainService : ICuponDomainService
{
    // Genera el codigo con la longitud de 12 digitos mas verificador
    public string GenerarCodigoCupon(string prefijo, int serial)
    {
        if (prefijo.Length < 5 || prefijo.Length > 8)
            throw new ArgumentException("El prefijo debe tener entre 5 y 8 dígitos.");

        int longitudSerial = 12 - (2 + prefijo.Length); // 12 total sin el dígito verificador

        if (longitudSerial <= 0)
            throw new InvalidOperationException("La combinación de prefijo y serial no permite construir un código GTIN-13 válido.");

        string serialFormateado = serial.ToString($"D{longitudSerial}");

        string baseCode = $"99{prefijo}{serialFormateado}"; // Total: 12 dígitos
        int digitoVerificador = DigitoVerificadorHelper.CalcularGTIN13(baseCode);

        return baseCode + digitoVerificador;
    }
    //Valida que las fechas sean correctas al momento de la peticion
    public void ValidarFechas(DateOnly fechaInicio, DateOnly? fechaCaducidad)
    {
        if (fechaCaducidad.HasValue && fechaInicio > fechaCaducidad.Value)
        {
            throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de caducidad.");
        }

        if (fechaInicio < DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ArgumentException("La fecha de inicio no puede estar en el pasado.");
        }
    }

    //Verifica que el cupon sea vigente, caducado o permitido
    public bool EsCuponVigente(DateOnly fechaInicio, DateOnly? fechaCaducidad)
    {
        var hoy = DateOnly.FromDateTime(DateTime.Today);

        if (fechaInicio > hoy)
            return false; // Aún no es vigente

        if (fechaCaducidad.HasValue && hoy > fechaCaducidad.Value)
            return false; // Ya caducó

        return true; // Está dentro del rango permitido
    }

}
