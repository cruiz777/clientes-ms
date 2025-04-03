using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record ProvinciaRequest
    {
        [JsonPropertyName("id_Provincia")]
        public long IdProvincia { get; set; }
        [JsonPropertyName("referencia")]
        public string Referencia { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public long IdPais { get; set; } = 0;
        public ProvinciaRequest() { }
        public ProvinciaRequest(long IdProvincia, string Referencia,string Nombre,long IdPais)
        {
            this.IdProvincia = IdProvincia;
            this.Referencia = Referencia.Trim();
            this.Nombre = Nombre.Trim();
            this.IdPais = IdPais;

        }
    }

}
