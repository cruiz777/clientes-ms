using clientes_ms.Application.Commands.Cupon;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Interfaces.IDomainServices;
using clientes_ms.libs;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Data;

namespace clientes_ms.Application.Handlers.Cupon
{
    public class DeleteCuponHandler : IRequestHandler<DeleteCuponCommand, ApiResponse<bool>>
    {
        private readonly IConfiguration _configuration;
        private readonly IAuditoriaDomainService _auditoriaDomainService;

        public DeleteCuponHandler(
            IConfiguration configuration,
            IAuditoriaDomainService auditoriaDomainService)
        {
            _configuration = configuration;
            _auditoriaDomainService = auditoriaDomainService;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteCuponCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Ids == null || !request.Ids.Any())
                    return ApiResponse<bool>.Error("Parámetros inválidos: no se encontraron IDs.");

                if (request.Usuario == 0)
                    return ApiResponse<bool>.Error("Parámetro inválido: el usuario es obligatorio.");

                // Solo una llamada al DomainService, que ejecuta el SP con auditoría incluida
                await _auditoriaDomainService.AuditarCuponDeleteAsync(request.Ids, request.Usuario, request.Observacion);

                return new ApiResponse<bool>(
                    Id: Guid.NewGuid(),
                    Type: "SUCCESS",
                    Data: true,
                    Message: "Cupones eliminados con auditoría correctamente"
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Error($"Error al eliminar cupones: {ex.Message}");
            }
        }
    }
}
