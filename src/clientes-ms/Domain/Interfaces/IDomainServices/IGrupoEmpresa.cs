using System.Threading.Tasks;

namespace clientes_ms.Domain.Interfaces.IDomainServices
{
    /// <summary>
    /// Define las reglas de negocio para la entidad GrupoEmpresa
    /// </summary>
    public interface IGrupoEmpresaDomainService
    {
        /// <summary>
        /// Verifica si el código ya existe, excluyendo opcionalmente un ID.
        /// </summary>
        Task<bool> CodigoYaExisteAsync(string codigo, long? idIgnorar = null);

        /// <summary>
        /// Verifica si el nombre ya existe, excluyendo opcionalmente un ID.
        /// </summary>
        Task<bool> NombreYaExisteAsync(string nombre, long? idIgnorar = null);
       
        /// <summary>
        /// Verifica si se puede desactivar un grupo de clientes que este atado a un cliente.
        /// </summary>
        Task<bool> PuedeDesactivarseAsync(long idGrupoEmpresa);
    }
}
