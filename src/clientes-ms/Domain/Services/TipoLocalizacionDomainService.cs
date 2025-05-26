using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Domain.Services
{
    public class TipoLocalizacionDomainService : ITipoLocalizacionDomainService
    {
        private readonly IBaseRepository<TipoLocalizacion> _repository;

        public TipoLocalizacionDomainService(IBaseRepository<TipoLocalizacion> repository)
        {
            _repository = repository;
        }

        public async Task<bool> DescripcionYaExisteAsync(string descripcion, long? idIgnorar = null)
        {
            var desc = descripcion.Trim().ToUpper();

            var existe = await _repository.FirstOrDefaultAsync(t =>
                t.Descripcion!.ToUpper() == desc &&
                (!idIgnorar.HasValue || t.IdTipoLocalizacion != idIgnorar.Value));

            return existe is not null;
        }

        public async Task<bool> PuedeDesactivarseAsync(long idTipoLocalizacion)
        {
            var tipoLoc = await _repository
                .AsQueryable()
                .Include(t => t.Gln) // Asegúrate que existe la navegación
                .FirstOrDefaultAsync(t => t.IdTipoLocalizacion == idTipoLocalizacion);

            return tipoLoc != null && (tipoLoc.Gln == null || !tipoLoc.Gln.Any());
        }
    }
}
