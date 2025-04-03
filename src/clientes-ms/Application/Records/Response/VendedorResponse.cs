using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Vendedor, pero ahora con la respuesta que necesitas obtener
    public record VendedorResponse
    {
        [JsonPropertyName("id")]
        public long IdVendedor { get; set; }
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
        public string Ruc { get; set; } = string.Empty;
        public string PorVendedor { get; set; } = string.Empty;
        public DateOnly Fecing { get; set; }
        public DateOnly Fecsal { get; set; }
        public short Estado { get; set; }
        public long EmpresaCodigo { get; set; } = 0;
        public VendedorResponse() { }
        public VendedorResponse(long id_vendedor, string Nombre, string Ruc,string PorVendedor,DateOnly Fecing,DateOnly Fecsal,short Estado, long EmpresaCodigo)
        {
            this.IdVendedor = id_vendedor;
            this.Nombre = Nombre.Trim();
            this.Ruc = Ruc.Trim();
            this.PorVendedor = PorVendedor.Trim();
            this.Fecing = Fecing; 
            this.Fecsal = Fecsal;
            this.Estado = Estado;
            this.EmpresaCodigo = EmpresaCodigo;
            

        }
    }
}
