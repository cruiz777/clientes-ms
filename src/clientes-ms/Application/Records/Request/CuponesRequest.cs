using System;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request;

public record CuponRequest
{
    [JsonPropertyName("idCliente")]
    public long IdCliente { get; set; }

    [JsonPropertyName("idPrefijo")]
    public long IdPrefijo { get; set; }

    [JsonPropertyName("serialInicio")]
    public int? SerialInicio { get; set; }

    [JsonPropertyName("cantidad")]
    public int Cantidad { get; set; }

    [JsonPropertyName("previsualizar")]
    public bool Previsualizar { get; init; } = false;

    [JsonPropertyName("fechaInicio")]
    public DateOnly FechaInicio { get; set; }

    [JsonPropertyName("fechaCaducidad")]
    public DateOnly? FechaCaducidad { get; set; }

    [JsonPropertyName("estado")]
    public bool Estado { get; set; } = true;

    [JsonPropertyName("idGrupoProducto")]
    public long? IdGrupoProducto { get; set; }

    [JsonPropertyName("descripcion")]
    public string? Descripcion { get; set; }
    [JsonPropertyName("usuario")]
    public long? IdUsuario { get; set; }
    public CuponRequest() { }

    public CuponRequest(
        long idCliente,
        long idPrefijo,
        int? serialInicio,
        int cantidad,
        DateOnly fechaInicio,
        DateOnly? fechaCaducidad,
        bool estado,
        long? idGrupoProducto,
        string? descripcion,
        long? usuario
    )
    {
        IdCliente = idCliente;
        IdPrefijo = idPrefijo;
        SerialInicio = serialInicio;
        Cantidad = cantidad;
        FechaInicio = fechaInicio;
        FechaCaducidad = fechaCaducidad;
        Estado = estado;
        IdGrupoProducto = idGrupoProducto;
        Descripcion = descripcion;
        IdUsuario = usuario;
    }
}
