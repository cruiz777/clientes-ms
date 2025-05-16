namespace clientes_ms.Application.DTOs.Clientes
{
    public record ClienteValidadoDTO(
        string NumeroRuc,
        string RazonSocial,
        string Representante,
        string EstadoContribuyente,
        DateOnly? FechaInicioActividad,
        DateOnly? FechaCeseActividad,
        string? MotivoCese
    );

}
