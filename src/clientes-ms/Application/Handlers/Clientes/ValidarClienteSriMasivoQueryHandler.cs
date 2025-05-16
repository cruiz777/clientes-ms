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
    public class ValidarClientesSriMasivoQueryHandler : IRequestHandler<ValidarClientesSriMasivoQuery, ApiResponse<List<ClienteValidadoResultadoDTO>>>
    {
        private readonly IBaseRepository<Clientes> _repository;
        private readonly IClienteDomainService _clienteDomainService;

        public ValidarClientesSriMasivoQueryHandler(
            IBaseRepository<Clientes> repository,
            IClienteDomainService clienteDomainService)
        {
            _repository = repository;
            _clienteDomainService = clienteDomainService;
        }

        public async Task<ApiResponse<List<ClienteValidadoResultadoDTO>>> Handle(ValidarClientesSriMasivoQuery request, CancellationToken cancellationToken)
        {
            var resultados = new List<ClienteValidadoResultadoDTO>();

            try
            {
                // Recorremos cada ID recibido
                foreach (var id in request.ClienteIds)
                {
                    var cliente = await _repository.GetByIdAsync(id);
                    if (cliente == null || string.IsNullOrEmpty(cliente.Ruc))
                        continue;

                    var validado = await _clienteDomainService.ValidarClienteDesdeSriAsync(cliente.Ruc);
                    if (validado != null)
                    {
                        resultados.Add(new ClienteValidadoResultadoDTO(id, validado));
                    }
                }

                return new ApiResponse<List<ClienteValidadoResultadoDTO>>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    resultados,
                    "Clientes validados correctamente",
                    resultados.Count);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ClienteValidadoResultadoDTO>>(
                    Guid.NewGuid(),
                    "ERROR",
                    null,
                    $"Ocurrió un error durante el barrido: {ex.Message}");
            }
        }
    }
}
