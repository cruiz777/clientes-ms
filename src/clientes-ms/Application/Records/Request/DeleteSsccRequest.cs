using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request;

public record DeleteSsccRequest
{
    [JsonPropertyName("ids")]
    public List<long> Ids { get; set; } = new();

    [JsonPropertyName("observacion")]
    public string Observacion { get; set; } = string.Empty;
    [JsonPropertyName("usuario")]
    public long Usuario { get; set; }
}
