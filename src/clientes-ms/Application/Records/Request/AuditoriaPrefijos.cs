using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    public record AuditoriaPrefijosRequest
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("codpre")]
        public string Codpre { get; set; } = string.Empty;

        [JsonPropertyName("usuario")]
        public string Usuario { get; set; } = string.Empty;

        [JsonPropertyName("fecha")]
        public string Fecha { get; set; } = string.Empty;

        [JsonPropertyName("empresa")]
        public string Empresa { get; set; } = string.Empty;

        [JsonPropertyName("ruc")]
        public string Ruc { get; set; } = string.Empty;

        public AuditoriaPrefijosRequest() { }

        public AuditoriaPrefijosRequest(long id, string codpre, string usuario, string fecha, string empresa, string ruc)
        {
            Id = id;
            Codpre = codpre.Trim();
            Usuario = usuario.Trim();
            Fecha = fecha.Trim();
            Empresa = empresa.Trim();
            Ruc = ruc.Trim();
        }
    }
}
