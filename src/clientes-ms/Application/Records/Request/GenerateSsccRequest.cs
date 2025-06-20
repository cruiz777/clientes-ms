using System.Text.Json;
using System.Text.Json.Serialization;

public record GenerateSsccRequest
{
    [JsonPropertyName("id_prefijo")]
    public long IdPrefijo { get; init; }
    [JsonPropertyName("id_cliente")]
    public long IdCliente { get; init; }
    [JsonPropertyName("indicador")]
    public byte Indicador { get; init; }
    [JsonPropertyName("producto_codificado")]
    public string? ProductoCodificado { get; init; } = string.Empty;
    [JsonPropertyName("serie")]
    public bool Serie { get; init; }
    [JsonPropertyName("secuencia_inicio")]
    public int? SecuenciaInicio { get; init; }
    [JsonPropertyName("cantidad_codigos")]
    public int CantidadCodigos { get; init; }
    [JsonPropertyName("usuario")]
    public string Usuario { get; init; } = string.Empty;
}