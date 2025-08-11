using clientes_ms.Application.Commands.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.libs;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace clientes_ms.Application.Handlers.Ssccs
{
    public class DeleteSsccHandler : IRequestHandler<DeleteSsccCommand, ApiResponse<bool>>
    {
        private readonly IConfiguration _configuration;

        public DeleteSsccHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteSsccCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var connectionString = EnvironmentConfiguration.GetConnectionString();

                if (string.IsNullOrWhiteSpace(connectionString) || request.Ids == null || !request.Ids.Any())
                    return ApiResponse<bool>.Error("Parámetros inválidos: no se encontraron IDs.");

                if (string.IsNullOrWhiteSpace(connectionString) || request.Usuario == 0 )
                    return ApiResponse<bool>.Error("Parámetros inválidos: no se ingreso el usuario que elimina.");

                var idsCsv = string.Join(",", request.Ids);

                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync(cancellationToken);

                using var command = new SqlCommand("[sic].[sp_EliminarSsccLoteConObservacion]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ids_sscc", idsCsv);
                command.Parameters.AddWithValue("@observacion", request.Observacion ?? string.Empty);
                command.Parameters.AddWithValue("@usuario", request.Usuario);

                await command.ExecuteNonQueryAsync(cancellationToken);

                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    true,
                    "Eliminación con auditoría completada exitosamente"
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Error($"Error al eliminar con auditoría: {ex.Message}");
            }
        }
    }
}
