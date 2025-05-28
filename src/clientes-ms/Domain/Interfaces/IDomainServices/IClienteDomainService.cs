using clientes_ms.Application.DTOs.Clientes;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Domain.Interfaces.IDomainServices
{
    public interface IClienteDomainService
    {
        Task<ClienteValidadoDTO?> ValidarClienteDesdeSriAsync(string ruc);

        Task<List<ClienteSummaryResponse>> GetClientesByNomcliAsync(string filtro);


    }
}
