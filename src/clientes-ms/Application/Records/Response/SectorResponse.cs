using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record SectorResponse
    {
        [JsonPropertyName("id")]
        public long IdSector { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;
        public SectorResponse() { }
        public SectorResponse(long id_sector, string descripcion)
        {
            this.IdSector = id_sector;
            this.Descripcion = descripcion.Trim();
          
        }
    }
}
