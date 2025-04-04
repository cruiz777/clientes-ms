using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record ContactosClientesRequest
    {
        [JsonPropertyName("id_ContactosClientes")]
        public long IdContactosClientes { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public long ClientesCodigo { get; set; } = 0;
        public ContactosClientesRequest() { }
        public ContactosClientesRequest(long IdContactosClientes, string Nombre,string Telefono,string Email,string Cargo,long ClienteCodigo)
        {
            this.IdContactosClientes = IdContactosClientes;
            this.Nombre = Nombre.Trim();
            this.Telefono = Telefono.Trim();
            this.Email = Email.Trim();
            this.Cargo = Cargo.Trim();
            this.ClientesCodigo = ClientesCodigo;

        }
    }

}
