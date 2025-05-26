using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request;

/// <summary>
/// Representa el DTO de entrada para crear o actualizar un Tipo de Código GS1.
/// </summary>
public record TipoCodigoGs1Request
{
    [JsonPropertyName("id_tipo_codigo_gs1")]
    public long IdTipoCodigoGs1 { get; set; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty;

    [JsonPropertyName("estado")]
    public bool Estado { get; set; } = true;  // Estado activo por defecto

    public TipoCodigoGs1Request() { }

    public TipoCodigoGs1Request(long id, string? descripcion, bool estado)
    {
        IdTipoCodigoGs1 = id;
        Descripcion = descripcion?.Trim() ?? string.Empty;
        Estado = estado;
    }
}
