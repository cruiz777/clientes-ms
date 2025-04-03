using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record VendedorRequest
    {
        [JsonPropertyName("id_Vendedor")]
        public long IdVendedor { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;
        public string Ruc { get; set; } = string.Empty;
        public string PorVendedor { get; set; } = string.Empty;
        public DateOnly Fecing { get; set; } 
        public DateOnly Fecsal{get; set; }
        public short Estado { get; set; }
        public long EmpresaCodigo { get; set; } = 0;
        public VendedorRequest() { }
        public VendedorRequest(long IdVendedor, string Nombre,string Ruc,string PorVendedor,DateOnly Fecing,DateOnly Fecsal,short estado,long EmpresaCodigo)
        {
            this.IdVendedor = IdVendedor;
            this.Nombre = Nombre.Trim();
            this.Ruc = Ruc.Trim();
            this.PorVendedor = PorVendedor;
            this.Fecing = Fecing; 
            this.Fecsal = Fecsal;
            this.Estado = estado;
            this.EmpresaCodigo = EmpresaCodigo;

        }
    }

}
