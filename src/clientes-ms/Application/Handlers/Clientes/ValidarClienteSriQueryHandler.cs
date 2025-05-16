using clientes_ms.Application.DTOs.Clientes;
using clientes_ms.Application.Queries.Clientes;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.Cliente
{
    public class ValidarClienteSriQueryHandler : IRequestHandler<ValidarClienteSriQuery, ApiResponse<ClienteValidadoDTO>>
    {
        private readonly IBaseRepository<Clientes> _repository;
        private readonly IClienteDomainService _clienteDomainService;

        public ValidarClienteSriQueryHandler(
            IBaseRepository<Clientes> repository,
            IClienteDomainService clienteDomainService)
        {
            _repository = repository;
            _clienteDomainService = clienteDomainService;
        }

        public async Task<ApiResponse<ClienteValidadoDTO>> Handle(ValidarClienteSriQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Buscar cliente en base por ID
                var cliente = await _repository.GetByIdAsync(request.ClienteId);
                if (cliente == null)
                {
                    return new ApiResponse<ClienteValidadoDTO>(
                        Guid.NewGuid(),
                        "NOT_FOUND",
                        null,
                        "Cliente no encontrado");
                }

                // Llamar servicio de dominio que consulta el SRI
                var resultado = await _clienteDomainService.ValidarClienteDesdeSriAsync(cliente.Ruc ?? string.Empty);
                if (resultado == null)
                {
                    return new ApiResponse<ClienteValidadoDTO>(
                        Guid.NewGuid(),
                        "NOT_FOUND",
                        null,
                        "No se pudo validar con el SRI");
                }

                // Devolver resultado exitoso
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
