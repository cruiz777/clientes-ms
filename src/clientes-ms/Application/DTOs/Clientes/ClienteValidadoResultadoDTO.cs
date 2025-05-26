namespace clientes_ms.Application.DTOs.Clientes
{
    public record ClienteValidadoResultadoDTO(
        long ClienteId,
        ClienteValidadoDTO DatosValidados
    );

}
