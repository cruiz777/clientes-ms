using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record HistorialClienteRequest
    {
        [JsonPropertyName("id_historial_cliente")]
        public long IdHistorialCliente { get; init; }

        [JsonPropertyName("id_usuario")]
        public long IdUsuario { get; set; } = 0;
        [JsonPropertyName("nombre_usuario")]
        public string NombreUsuario { get; set; } = string.Empty;
        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;
        [JsonPropertyName("clientes_codigo")]
        public long ClientesCodigo { get; init; } = 0;


        public HistorialClienteRequest() { }
        public HistorialClienteRequest(long id_historial_cliente,long id_usuario,string nombre_usuario,DateTime fecha, string descripcion,long clientes_codigo)
        {
            this.IdHistorialCliente = id_historial_cliente;
            this.IdUsuario = id_usuario;
            this.NombreUsuario = nombre_usuario;
            this.Fecha = fecha;
            this.Descripcion = descripcion.Trim();
            this.ClientesCodigo = clientes_codigo;
            

           
        }
    }

}
