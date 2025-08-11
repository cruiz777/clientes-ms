public interface IParametroDomainService
{
    Task<string?> ObtenerValorParametroAsync(string clave, string ambiente = "dev", long? idEmpresa = null);
}
