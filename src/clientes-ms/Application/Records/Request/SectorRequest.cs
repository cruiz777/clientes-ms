using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record SectorRequest
    {
        [JsonPropertyName("id_sector")]
        public long IdSector { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        public SectorRequest() { }
        public SectorRequest(long IdSector, string Descripcion)
        {
            this.IdSector = IdSector;
            this.Descripcion = Descripcion.Trim();
           
        }
    }

}
