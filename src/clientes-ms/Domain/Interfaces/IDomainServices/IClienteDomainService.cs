using clientes_ms.Application.DTOs.Clientes;

namespace clientes_ms.Domain.Interfaces.IDomainServices
{
    public interface IClienteDomainService
    {
        Task<ClienteValidadoDTO?> ValidarClienteDesdeSriAsync(string ruc);

    }
}
