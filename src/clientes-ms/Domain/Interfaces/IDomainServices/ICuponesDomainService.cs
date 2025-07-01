namespace clientes_ms.Domain.Interfaces.IDomainServices;

public interface ICuponDomainService
{
    string GenerarCodigoCupon(string prefijo, int serial);
    void ValidarFechas(DateOnly fechaInicio, DateOnly? fechaCaducidad);
    public bool EsCuponVigente(DateOnly fechaInicio, DateOnly? fechaCaducidad);

}
