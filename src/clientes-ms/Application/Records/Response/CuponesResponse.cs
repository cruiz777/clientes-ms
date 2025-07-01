using System;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response;

public record CuponResponse
{
    [JsonPropertyName("idCupon")]
    public long IdCupon { get; set; }

    [JsonPropertyName("codigoCupon")]
    public string CodigoCupon { get; set; } = string.Empty;

    [JsonPropertyName("idCliente")]
    public long IdCliente { get; set; }

    [JsonPropertyName("idPrefijo")]
    public long IdPrefijo { get; set; }

    [JsonPropertyName("serial")]
    public int Serial { get; set; }

    [JsonPropertyName("fechaInicio")]
    public DateOnly FechaInicio { get; set; }

    [JsonPropertyName("fechaCaducidad")]
    public DateOnly? FechaCaducidad { get; set; }

    [JsonPropertyName("estado")]
    public bool? Estado { get; set; }

    public CuponResponse() { }

    public CuponResponse(long idCupon, string codigoCupon, long idCliente, long idPrefijo, int serial, DateOnly fechaInicio, DateOnly? fechaCaducidad, bool? estado)
    {
        IdCupon = idCupon;
        CodigoCupon = codigoCupon;
        IdCliente = idCliente;
        IdPrefijo = idPrefijo;
        Serial = serial;
        FechaInicio = fechaInicio;
        FechaCaducidad = fechaCaducidad;
        Estado = estado;
    }
}
