using clientes_ms.Application.Queries.Clientes;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;

namespace clientes_ms.Application.Handlers.Clientes
{
    public class GetClientesByNomcliAsyncHandler : IRequestHandler<GetClientesByNomcliAsyncQuery, ApiResponse<List<ClienteSummaryResponse>>>
    {
        private readonly IClienteDomainService _clienteDomainService;

        public GetClientesByNomcliAsyncHandler(IClienteDomainService clienteDomainService)
        {
            _clienteDomainService = clienteDomainService;
        }

        public async Task<ApiResponse<List<ClienteSummaryResponse>>> Handle(GetClientesByNomcliAsyncQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _clienteDomainService.GetClientesByNomcliAsync(request.Nomcli);
                return new ApiResponse<List<ClienteSummaryResponse>>(Guid.NewGuid(), "OK", resultado, "ok");
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ClienteSummaryResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
            }
        }

    }
}
