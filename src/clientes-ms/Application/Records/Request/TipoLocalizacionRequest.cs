using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record TipoLocalizacionRequest
    {
        [JsonPropertyName("id_tipo_cliente")]
        public long IdTipoLocalizacion { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

    

        public bool Estado { get; set; } = false;
        public TipoLocalizacionRequest() { }
        public TipoLocalizacionRequest(long IdTipoLocalizacion, string Descripcion,bool Estado)
        {
            this.IdTipoLocalizacion = IdTipoLocalizacion;
            this.Descripcion = Descripcion.Trim();
         
            this.Estado = Estado;

           
        }
    }

}
