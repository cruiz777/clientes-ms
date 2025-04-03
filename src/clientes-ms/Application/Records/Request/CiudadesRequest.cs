using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record CiudadesRequest
    {
        [JsonPropertyName("id_Ciudad")]
        public long IdCiudad { get; set; }
        [JsonPropertyName("referencia")]
        public string Referencia { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public long IdCanton { get; set; } = 0;
        public CiudadesRequest() { }
        public CiudadesRequest(long IdCiudad, string Referencia,string Nombre,string Area,long IdCanton)
        {
            this.IdCanton = IdCanton;
            this.Referencia = Referencia.Trim();
            this.Nombre = Nombre.Trim();
            this.Area = Area.Trim();
            this.IdCanton = IdCanton;

        }
    }

}
