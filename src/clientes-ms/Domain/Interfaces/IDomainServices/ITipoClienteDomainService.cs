using System.Threading.Tasks;

namespace clientes_ms.Domain.Interfaces.IDomainServices
{
    public interface ITipoClienteDomainService
    {
        Task<bool> DescripcionYaExisteAsync(string descripcion, long? idIgnorar = null);
        Task<bool> PuedeDesactivarseAsync(long idTipoCliente);
    }
}
