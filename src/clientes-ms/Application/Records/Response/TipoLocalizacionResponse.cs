using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record TipoLocalizacionResponse
    {
        [JsonPropertyName("id_tipo_cliente")]
        public long IdTipoLocalizacion { get; set; }
        [JsonPropertyName("descripcion")]

        public string Descripcion { get; set; } = string.Empty;

        public bool Estado { get; set; } = false;

     
        public TipoLocalizacionResponse() { }
        public TipoLocalizacionResponse(long id_tipo_cliente, string descripcion,bool estado)
        {
            this.IdTipoLocalizacion = id_tipo_cliente;
            this.Descripcion = descripcion.Trim();
          
            this.Estado = estado;
          
        }
    }
}
