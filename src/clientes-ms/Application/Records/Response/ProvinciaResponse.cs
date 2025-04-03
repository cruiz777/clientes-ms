using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record ProvinciaResponse
    {
        [JsonPropertyName("id")]
        public long IdProvincia { get; set; }
        [JsonPropertyName("Referencia")]
        public string Referencia { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public long IdPais { get; set; } = 0;
        public ProvinciaResponse() { }
        public ProvinciaResponse(long id_Provincia, string Referencia,string Nombre,long IdPais)
        {
            this.IdProvincia = id_Provincia;
            this.Referencia = Referencia.Trim();
            this.Nombre = Nombre.Trim();
            this.IdPais = IdPais;

        }
    }
}
