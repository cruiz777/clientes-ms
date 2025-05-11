using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record TipoClienteRequest
    {
        [JsonPropertyName("id_tipo_cliente")]
        public long IdTipoCliente { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        public string Cuenta { get; set; } = string.Empty;

        public long IdEmpresa { get; set; } = 0;

        public bool Estado { get; set; } = false;
        public TipoClienteRequest() { }
        public TipoClienteRequest(long IdTipoCliente, string Descripcion,string Cuenta,long IdEmpresa,bool Estado)
        {
            this.IdTipoCliente = IdTipoCliente;
            this.Descripcion = Descripcion.Trim();
            this.Cuenta = Cuenta.Trim();
            this.IdEmpresa = IdEmpresa;
            this.Estado = Estado;

           
        }
    }

}
