using clientes_ms.Application.DTOs.Clientes;
using clientes_ms.Application.Queries.Clientes;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using System.Text.RegularExpressions;

namespace clientes_ms.Application.Handlers.Cliente
{
    public class ValidarClienteSriQueryHandler : IRequestHandler<ValidarClienteSriQuery, ApiResponse<ClienteValidadoDTO>>
    {
        private readonly IBaseRepository<clientes_ms.Domain.Entities.Clientes> _repository;
        private readonly IClienteDomainService _clienteDomainService;

        public ValidarClienteSriQueryHandler(
            IBaseRepository<clientes_ms.Domain.Entities.Clientes> repository,
            IClienteDomainService clienteDomainService)
        {
            _repository = repository;
            _clienteDomainService = clienteDomainService;
        }

        public async Task<ApiResponse<ClienteValidadoDTO>> Handle(ValidarClienteSriQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _repository.GetByIdAsync(request.ClienteId);
                if (cliente == null)
                {
                    return new ApiResponse<ClienteValidadoDTO>(
                        Guid.NewGuid(),
                        "NOT_FOUND",
                        null,
                        "Cliente no encontrado");
                }

                if (string.IsNullOrWhiteSpace(cliente.Ruc) || !Regex.IsMatch(cliente.Ruc, @"^\d{13}$"))
                {
                    return new ApiResponse<ClienteValidadoDTO>(
                        Guid.NewGuid(),
                        "INVALID_RUC",
                        null,
                        "El RUC no es válido. Debe tener exactamente 13 dígitos numéricos.");
                }

                var resultado = await _clienteDomainService.ValidarClienteDesdeSriAsync(cliente.Ruc);
                if (resultado == null)
                {
                    return new ApiResponse<ClienteValidadoDTO>(
                        Guid.NewGuid(),
                        "NOT_FOUND",
                        null,
                        "No se pudo validar con el SRI");
                }

                return new ApiResponse<ClienteValidadoDTO>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    resultado,
                    "Validación exitosa");
            }
            catch (Exception ex)
            {
                return new ApiResponse<ClienteValidadoDTO>(
                    Guid.NewGuid(),
                    "ERROR",
                    null,
                    $"Ocurrió un error durante la validación: {ex.Message}");
            }
        }
    }
}
