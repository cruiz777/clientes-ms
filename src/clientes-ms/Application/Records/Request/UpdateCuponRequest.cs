using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    public record UpdateEstadoRequest
    {
        [JsonPropertyName("estado")]
        public bool Estado { get; set; }
    }
}
