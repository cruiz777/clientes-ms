using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record TipoClienteResponse
    {
        [JsonPropertyName("id_tipo_cliente")]
        public long IdTipoCliente { get; init; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; init; } = string.Empty;
        [JsonPropertyName("cuenta")]
        public string Cuenta { get; init; } = string.Empty;
        [JsonPropertyName("estado")]
        public bool Estado { get; init; } = false;
        [JsonPropertyName("id_empresa")]
        public long IdEmpresa { get; init; } = 0;
        [JsonPropertyName("empresa")]
        public string Empresa {  get; init; } = string.Empty;

     
        public TipoClienteResponse() { }
        public TipoClienteResponse(long id_tipo_cliente, string descripcion,string cuenta,long id_empresa,bool estado,string empresa)
        {
            this.IdTipoCliente = id_tipo_cliente;
            this.Descripcion = descripcion.Trim();
            this.Cuenta=cuenta.Trim();
            this.IdEmpresa=id_empresa;
            this.Estado = estado;
            this.Empresa = empresa;
           
          
        }
    }
}
