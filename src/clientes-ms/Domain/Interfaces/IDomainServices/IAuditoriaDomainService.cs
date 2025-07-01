using System.Threading.Tasks;

namespace clientes_ms.Domain.Interfaces.IDomainServices;

public interface IAuditoriaDomainService
{
    Task AuditarSsccCreateOrUpdateAsync(string accion, long idSscc, string usuario, string? observacion = null);
    Task AuditarCuponDeleteAsync(IEnumerable<long> idsCupon, long usuario, string? observacion = null);

}
