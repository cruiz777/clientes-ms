using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Domain.Services
{
    public class TipoClienteDomainService : ITipoClienteDomainService
    {
        private readonly IBaseRepository<TipoCliente> _repository;

        public TipoClienteDomainService(IBaseRepository<TipoCliente> repository)
        {
            _repository = repository;
        }
        //Valida que no exista un tipo de cliente con la misma descripcion
        public async Task<bool> DescripcionYaExisteAsync(string descripcion, long? idIgnorar = null)
        {
            var desc = descripcion.Trim().ToUpper();

            var existente = await _repository.FirstOrDefaultAsync(tc =>
                tc.Descripcion!.ToUpper() == desc &&
                (!idIgnorar.HasValue || tc.IdTipoCliente != idIgnorar.Value));

            return existente is not null;
        }
        //Valida que no existan clientes asociados al tipo de cliente antes de desactivarlo
        public async Task<bool> PuedeDesactivarseAsync(long idTipoCliente)
        {
            var tipoCliente = await _repository
                .AsQueryable()
                .Include(tc => tc.Clientes)
                .FirstOrDefaultAsync(tc => tc.IdTipoCliente == idTipoCliente);

            if (tipoCliente == null)
                return false;

            return tipoCliente.Clientes == null || !tipoCliente.Clientes.Any();
        }
    }
}
