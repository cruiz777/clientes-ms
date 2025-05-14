namespace clientes_ms.Domain.Interfaces.IDomainServices
{
    public interface ITipoLocalizacionDomainService
    {
        Task<bool> DescripcionYaExisteAsync(string descripcion, long? idIgnorar = null);
        Task<bool> PuedeDesactivarseAsync(long idTipoLocalizacion);
    }
}
