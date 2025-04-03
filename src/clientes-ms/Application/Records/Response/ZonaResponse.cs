using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record ZonaResponse
    {
        [JsonPropertyName("id")]
        public long IdZona { get; set; }
        [JsonPropertyName("referencia")]
        public string Referencia { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;

        public long EmpresaCodigo { get; set; } = 0;
        public ZonaResponse() { }
        public ZonaResponse(long id_zona, string referencia,string nombre,string numero,long empresacodigo)
        {
            this.IdZona = id_zona;
            this.Referencia = referencia.Trim();
            this.Nombre= nombre.Trim();
            this.Numero= numero.Trim();
            this.EmpresaCodigo=empresacodigo;
          
        }
    }
}
