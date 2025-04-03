using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record TipoClienteResponse
    {
        [JsonPropertyName("id_tipo_cliente")]
        public long IdTipoCliente { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        public string Cuenta { get; set; } = string.Empty;

        public long EmpresaCodigo { get; set; } = 0;
        public TipoClienteResponse() { }
        public TipoClienteResponse(long id_tipo_cliente, string descripcion,string cuenta,long empresa_codigo)
        {
            this.IdTipoCliente = id_tipo_cliente;
            this.Descripcion = descripcion.Trim();
            this.Cuenta=cuenta.Trim();
            this.EmpresaCodigo=empresa_codigo;
          
        }
    }
}
