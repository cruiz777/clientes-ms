using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Domain.Services
{
    /// <summary>
    /// Implementación de las reglas de negocio para GrupoEmpresa
    /// </summary>
    public class GrupoEmpresaDomainService : IGrupoEmpresaDomainService
    {
        private readonly IBaseRepository<GrupoEmpresa> _repository;

        public GrupoEmpresaDomainService(IBaseRepository<GrupoEmpresa> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CodigoYaExisteAsync(string codigo, long? idIgnorar = null)
        {
            var codigoTrim = codigo.Trim().ToUpper();
            var existente = await _repository.FirstOrDefaultAsync(g =>
                g.Codigo!.ToUpper() == codigoTrim &&
                (!idIgnorar.HasValue || g.IdGrupoEmpresa != idIgnorar.Value));

            return existente is not null;
        }

        public async Task<bool> NombreYaExisteAsync(string nombre, long? idIgnorar = null)
        {
            var nombreTrim = nombre.Trim().ToUpper();
            var existente = await _repository.FirstOrDefaultAsync(g =>
                g.Nombre!.ToUpper() == nombreTrim &&
                (!idIgnorar.HasValue || g.IdGrupoEmpresa != idIgnorar.Value));

            return existente is not null;
        }
    }
}
