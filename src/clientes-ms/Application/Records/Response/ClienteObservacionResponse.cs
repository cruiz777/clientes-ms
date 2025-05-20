using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de ClienteObservacion, pero ahora con la respuesta que necesitas obtener
    public record ClienteObservacionResponse
    {
        [JsonPropertyName("id")]
        public long IdClienteObservacion { get; set; }
        [JsonPropertyName("Detalle")]
        public string Detalle { get; set; } = string.Empty;
        
        public DateTime Fecha { get; set; }
        
        public long IdUsuario { get; set; } = 0;
        public long ClientesCodigo { get; set; } = 0;
        public string NombreUsuario { get; set; }=string.Empty;
        public int Linea { get; set; } = 0;
        public ClienteObservacionResponse() { }
        public ClienteObservacionResponse(long id_ClienteObservacion, string Detalle, DateTime Fecha, long IdUsuario,long ClientesCodigo,string NombreUsuario,int Linea)
        {
            this.IdClienteObservacion = id_ClienteObservacion;
            this.Detalle = Detalle.Trim();
            this.Fecha = Fecha; 
            this.IdUsuario = IdUsuario;
            this.ClientesCodigo = ClientesCodigo;
            this.NombreUsuario = NombreUsuario;
            this.Linea = Linea;

        }
    }
}
