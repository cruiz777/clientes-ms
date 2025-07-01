using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public record AuditoriaPrefijosResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("codpre")]
        public string? Codpre { get; set; }

        [JsonPropertyName("usuario")]
        public string? Usuario { get; set; }

        [JsonPropertyName("fecha")]
        public string? Fecha { get; set; }

        [JsonPropertyName("empresa")]
        public string? Empresa { get; set; }

        [JsonPropertyName("ruc")]
        public string? Ruc { get; set; }

        public AuditoriaPrefijosResponse() { }

        public AuditoriaPrefijosResponse(long id, string? codpre, string? usuario, string? fecha, string? empresa, string? ruc)
        {
            Id = id;
            Codpre = codpre;
            Usuario = usuario;
            Fecha = fecha;
            Empresa = empresa;
            Ruc = ruc;
        }
    }
}
