using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record NumeroControlRequest
    {
        [JsonPropertyName("id_NumeroControl")]
        public long IdNumeroControl { get; set; }
        [JsonPropertyName("codcon")]
        public double Codcon { get; set; } = 0;
        public string Modcon { get; set; } = string.Empty;
        public string Tipcon { get; set; } = string.Empty;
        public string Numcon { get; set; } = string.Empty;
        public bool Ocupado {  get; set; } = false;
        public long EmpresaCodigo { get; set; } = 0;
        public NumeroControlRequest() { }
        public NumeroControlRequest(long IdNumeroControl, double Codcon,string Modcon,string Tipcon,string Numcon,bool Ocupado,long EmpresaCodigo)
        {
            this.IdNumeroControl = IdNumeroControl;
            this.Codcon = Codcon;
            this.Modcon = Modcon.Trim();
            this.Tipcon = Tipcon.Trim();
            this.Numcon = Numcon.Trim();
            this.Ocupado = Ocupado;
            this.EmpresaCodigo = EmpresaCodigo;

        }
    }

}
