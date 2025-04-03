using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record NumeroControlResponse
    {
        [JsonPropertyName("id")]
        public long IdNumeroControl { get; set; }
        [JsonPropertyName("codcon")]
        public double Codcon { get; set; } = 0;
        public string Modcon { get; set; } = string.Empty;
        public string Tipcon { get; set; } = string.Empty;
        public string Numcon { get; set; } = string.Empty;
        public bool Ocupado {  get; set; } = false;
        public long EmpresaCodigo { get; set; } = 0;
        public NumeroControlResponse() { }
        public NumeroControlResponse(long id_NumeroControl, double Codcon,string Modcon,string Tipcon,string Numcon,bool Ocupado,long EmpresaCodigo)
        {
            this.IdNumeroControl = id_NumeroControl;
            this.Codcon = Codcon;
            this.Modcon = Modcon.Trim();
            this.Tipcon = Tipcon.Trim();
            this.Numcon = Numcon.Trim();
            this.Ocupado = Ocupado;
            this.EmpresaCodigo = EmpresaCodigo;

        }
    }
}
