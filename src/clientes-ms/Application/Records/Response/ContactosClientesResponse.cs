using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record ContactosClientesResponse
    {
        [JsonPropertyName("id")]
        public long IdContactosClientes { get; set; }
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public long ClientesCodigo { get; set; } = 0;
        public ContactosClientesResponse() { }
        public ContactosClientesResponse(long id_ContactosClientes, string Nombre,string Telefono,string Email,string Cargo,long ClientesCodigo)
        {
            this.IdContactosClientes = id_ContactosClientes;
            this.Nombre = Nombre.Trim();
            this.Telefono = Telefono.Trim();
            this.Cargo = Cargo.Trim();
            this.Email = Email.Trim();
            this.ClientesCodigo= ClientesCodigo;

        }
    }
}
