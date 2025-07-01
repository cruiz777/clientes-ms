using MicroservicesTemplate.Domain.Repositories;
using clientes_ms.Domain.Interfaces.IDomainServices;
using clientes_ms.Domain.Entities;

public class ParametroDomainService : IParametroDomainService
{
    private readonly IBaseRepository<Parametros> _parametroRepo;
    private readonly IBaseRepository<ParametrosDetalle> _detalleRepo;

    public ParametroDomainService(
        IBaseRepository<Parametros> parametroRepo,
        IBaseRepository<ParametrosDetalle> detalleRepo)
    {
        _parametroRepo = parametroRepo;
        _detalleRepo = detalleRepo;
    }

    public async Task<string?> ObtenerValorParametroAsync(string clave, string ambiente = "dev", long? idEmpresa = null)
    {
        var parametro = await _parametroRepo.FirstOrDefaultAsync(p =>
            p.Clave == clave && p.Activo == true);

        if (parametro == null) return null;

        var detalle = await _detalleRepo.FirstOrDefaultAsync(d =>
            d.IdParametro == parametro.Id &&
            d.Ambiente == ambiente &&
            d.Activo == true &&
            (idEmpresa == null || d.IdEmpresa == idEmpresa));

        return detalle?.Valor;
    }
}
