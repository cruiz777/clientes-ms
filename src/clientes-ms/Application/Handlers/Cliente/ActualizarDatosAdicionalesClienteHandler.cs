using clientes_ms.Application.Commands.Clientes;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace clientes_ms.Application.Handlers.Cliente
{
    public class ActualizarDatosAdicionalesClienteHandler
        : IRequestHandler<ActualizarDatosAdicionalesClienteCommand, ApiResponse<bool>>
    {
        private readonly ApplicationDbContext _context;

        public ActualizarDatosAdicionalesClienteHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<bool>> Handle(
            ActualizarDatosAdicionalesClienteCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var r = request.Request;

                if (r == null)
                {
                    return new ApiResponse<bool>(
                        Guid.NewGuid(),
                        "WARNING",
                        false,
                        "La solicitud no puede ser nula.",
                        0
                    );
                }

                if (r.ClientesCodigo <= 0)
                {
                    return new ApiResponse<bool>(
                        Guid.NewGuid(),
                        "WARNING",
                        false,
                        "Debe enviar el código del cliente.",
                        0
                    );
                }

                bool existeCliente = await _context.Set<Clientes>()
                    .AsNoTracking()
                    .AnyAsync(x =>
                        x.ClientesCodigo == r.ClientesCodigo,
                        cancellationToken);

                if (!existeCliente)
                {
                    return new ApiResponse<bool>(
                        Guid.NewGuid(),
                        "WARNING",
                        false,
                        "No existe el cliente seleccionado.",
                        0
                    );
                }

                var adicional = await _context.Set<ClienteDatosAdicionales>()
                    .FirstOrDefaultAsync(x =>
                        x.ClientesCodigo.HasValue &&
                        x.ClientesCodigo.Value == r.ClientesCodigo,
                        cancellationToken);

                if (adicional == null)
                {
                    adicional = new ClienteDatosAdicionales();

                    AsignarLong(
                        adicional,
                        "ClientesCodigo",
                        r.ClientesCodigo);

                    AsignarNumeroOBool(
                        adicional,
                        "Estado",
                        true);

                    _context.Set<ClienteDatosAdicionales>().Add(adicional);
                }

                /*
                 * Tabla: sic.cliente_datos_adicionales
                 *
                 * checkPrefijo -> prefijo
                 * checkGuia    -> guia
                 * checkOtros   -> otros
                 */
                AsignarNumeroOBool(
                    adicional,
                    "Prefijo",
                    r.CheckPrefijo);

                AsignarNumeroOBool(
                    adicional,
                    "Guia",
                    r.CheckGuia);

                AsignarNumeroOBool(
                    adicional,
                    "Otros",
                    r.CheckOtros);

                AsignarNumeroOBool(
                    adicional,
                    "Estado",
                    true);

                await _context.SaveChangesAsync(cancellationToken);

                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    true,
                    "Datos adicionales actualizados correctamente.",
                    1
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Error(
                    $"Error al actualizar datos adicionales del cliente: {ex.Message}");
            }
        }

        private static void AsignarLong(
            object entity,
            string propertyName,
            long value)
        {
            var prop = ObtenerPropiedad(entity, propertyName);

            if (prop == null || !prop.CanWrite)
                return;

            var targetType = Nullable.GetUnderlyingType(prop.PropertyType)
                             ?? prop.PropertyType;

            object valorConvertido;

            if (targetType == typeof(long))
                valorConvertido = value;
            else if (targetType == typeof(int))
                valorConvertido = Convert.ToInt32(value);
            else if (targetType == typeof(short))
                valorConvertido = Convert.ToInt16(value);
            else if (targetType == typeof(byte))
                valorConvertido = Convert.ToByte(value);
            else
                valorConvertido = Convert.ChangeType(value, targetType);

            prop.SetValue(entity, valorConvertido);
        }

        private static void AsignarNumeroOBool(
            object entity,
            string propertyName,
            bool value)
        {
            var prop = ObtenerPropiedad(entity, propertyName);

            if (prop == null || !prop.CanWrite)
                return;

            var targetType = Nullable.GetUnderlyingType(prop.PropertyType)
                             ?? prop.PropertyType;

            object valorConvertido;

            if (targetType == typeof(bool))
                valorConvertido = value;
            else if (targetType == typeof(int))
                valorConvertido = value ? 1 : 0;
            else if (targetType == typeof(short))
                valorConvertido = Convert.ToInt16(value ? 1 : 0);
            else if (targetType == typeof(byte))
                valorConvertido = Convert.ToByte(value ? 1 : 0);
            else if (targetType == typeof(long))
                valorConvertido = Convert.ToInt64(value ? 1 : 0);
            else if (targetType == typeof(string))
                valorConvertido = value ? "1" : "0";
            else
                valorConvertido = value ? 1 : 0;

            prop.SetValue(entity, valorConvertido);
        }

        private static PropertyInfo? ObtenerPropiedad(
            object entity,
            string propertyName)
        {
            return entity
                .GetType()
                .GetProperty(
                    propertyName,
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.IgnoreCase);
        }
    }
}