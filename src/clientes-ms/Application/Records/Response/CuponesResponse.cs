using System;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response;

public record CuponResponse
{
    [JsonPropertyName("idCupon")]
    public long IdCupon { get; init; }

    [JsonPropertyName("codigoCupon")]
    public string CodigoCupon { get; init; } = string.Empty;

    [JsonPropertyName("idCliente")]
    public long IdCliente { get; init; }

    [JsonPropertyName("idPrefijo")]
    public long IdPrefijo { get; init; }

    [JsonPropertyName("serial")]
    public int? Serial { get; init; }

    [JsonPropertyName("fechaInicio")]
    public DateOnly FechaInicio { get; init; }

    [JsonPropertyName("fechaCaducidad")]
    public DateOnly? FechaCaducidad { get; init; }
    [JsonPropertyName("fechaCreacion")]
    public DateTime? FechaCreacion { get; init; }

    [JsonPropertyName("estado")]
    public bool? Estado { get; init; }

    [JsonPropertyName("idGrupoProducto")]
    public long? IdGrupoProducto { get; init; }

    [JsonPropertyName("descripcion")]
    public string? Descripcion { get; init; }
    [JsonPropertyName("usuario")]
    public long? IdUsuario { get; init; }

    public CuponResponse() { }

    public CuponResponse(
        long idCupon,
        string codigoCupon,
        long idCliente,
        long idPrefijo,
        int? serial,
        DateOnly fechaInicio,
        DateOnly? fechaCaducidad,
        DateTime fechaCreacion,
        bool? estado,
        long? idGrupoProducto,
        string? descripcion,
        long? usuario
    )
    {
        IdCupon = idCupon;
        CodigoCupon = codigoCupon;
        IdCliente = idCliente;
        IdPrefijo = idPrefijo;
        Serial = serial;
        FechaInicio = fechaInicio;
        FechaCaducidad = fechaCaducidad;
        FechaCreacion = fechaCreacion;
        Estado = estado;
        IdGrupoProducto = idGrupoProducto;
        Descripcion = descripcion;
        IdUsuario = usuario;
    }
}
