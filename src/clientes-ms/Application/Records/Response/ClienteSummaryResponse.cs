using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public class ClienteSummaryResponse
    {
        [JsonPropertyName("clientes_codigo")]
        public long ClientesCodigo { get; init; }

        [JsonPropertyName("nomcli")]
        public string Nomcli { get; init; } = string.Empty;

        [JsonPropertyName("ruc")]
        public string Ruc { get; init; } = string.Empty;

        public ClienteSummaryResponse() { }

        public ClienteSummaryResponse(long clientes_codigo, string nomcli, string ruc)
        {
            this.ClientesCodigo = clientes_codigo;
            this.Nomcli = nomcli;
            this.Ruc = ruc;
        }
    }
}
