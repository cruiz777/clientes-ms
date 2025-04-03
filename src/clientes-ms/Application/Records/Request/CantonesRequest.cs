using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record CantonesRequest
    {
        [JsonPropertyName("id_Canton")]
        public long IdCanton { get; set; }
        [JsonPropertyName("referencia")]
        public string Referencia { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public long IdProvincia { get; set; } = 0;
        public CantonesRequest() { }
        public CantonesRequest(long IdCanton, string Referencia,string Nombre,long IdProvincia)
        {
            this.IdCanton = IdCanton;
            this.Referencia = Referencia.Trim();
            this.Nombre = Nombre.Trim();
            this.IdProvincia = IdProvincia;

        }
    }

}
