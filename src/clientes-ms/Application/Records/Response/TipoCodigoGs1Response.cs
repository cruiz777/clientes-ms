using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response;

/// <summary>
/// Representa el DTO de salida para mostrar información de un Tipo de Código GS1.
/// </summary>
public record TipoCodigoGs1Response
{
    [JsonPropertyName("id_tipo_codigo_gs1")]
    public long IdTipoCodigoGs1 { get; init; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; init; } = string.Empty;

    [JsonPropertyName("estado")]
    public bool Estado { get; init; }

    public TipoCodigoGs1Response() { }

    public TipoCodigoGs1Response(long id, string? descripcion, bool estado)
    {
        IdTipoCodigoGs1 = id;
        Descripcion = descripcion?.Trim() ?? string.Empty;
        Estado = estado;
    }
}
