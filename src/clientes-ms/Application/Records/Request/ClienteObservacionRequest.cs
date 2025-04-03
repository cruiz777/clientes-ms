using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record ClienteObservacionRequest
    {
        [JsonPropertyName("id_ClienteObservacion")]
        public long IdClienteObservacion { get; set; }
        [JsonPropertyName("detalle")]
        public string Detalle { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } 
      
        public long IdUsuario { get; set; } = 0;
        public long ClientesCodigo { get; set; } = 0;
        public ClienteObservacionRequest() { }
        public ClienteObservacionRequest(long IdClienteObservacion, string Detalle,DateTime Fecha,long IdUsuario,long ClientesCodigo)
        {
            this.IdClienteObservacion = IdClienteObservacion;
            this.Detalle = Detalle.Trim();
            this.Fecha = Fecha; 
            this.IdUsuario= IdUsuario;
            this.ClientesCodigo = ClientesCodigo;

        }
    }

}
