using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record PrefijosRequest
    {
        [JsonPropertyName("id_prefijos")]
        public long IdPrefijos { get; set; }
        [JsonPropertyName("codpre")]
        public string Codpre { get; set; } = string.Empty;

        public DateOnly Fecha { get; set; } = DateOnly.MinValue;

        public DateTime FechaCierre { get; set; } = DateTime.MinValue;
        public string Observacion { get; set; } = string.Empty;
        public string Digitos { get; set; } = string.Empty;
        public bool Estado { get; set; } =false;
        public int Control { get; set; } = 0;
        public int Ngln { get; set; } = 0;
        public int Bandera { get; set; } = 0;
        public string Facturar { get; set; } = string.Empty;
        public string Codpro { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Fecfac { get; set; } = string.Empty;
        public string ReferenciaInterna { get; set; } = string.Empty;
        public string Prefijosgs1 { get; set; } = string.Empty;
        public string OrigenPrefijo { get; set; } = string.Empty;
        public int Orden {  get; set; } = 0;
        public long ClientesCodigo { get; set; } = 0;
        public PrefijosRequest() { }
        public PrefijosRequest(long IdPrefijos, string Codpre, long ClientesCodigo, DateOnly Fecha,
 DateTime FechaCierre, string Observacion, string Digitos,
 bool Estado, int Control, int Ngln,
 int Bandera, string Facturar, string Codpro,
 string Nombre, string Fecfac, string ReferenciaInterna,
 string Prefijosgs1, string OrigenPrefijo, int Orden)
        {
            this.IdPrefijos = IdPrefijos;
            this.Codpre = Codpre.Trim();    
            this.Fecha = Fecha;
            this.FechaCierre = FechaCierre;
            this.Observacion = Observacion.Trim();
            this.Digitos = Digitos.Trim();
            this.Estado = Estado;
            this.Control = Control;
            this.Ngln = Ngln;
            this.Bandera = Bandera;
            this.Facturar = Facturar.Trim();
            this.Codpro = Codpro.Trim();
            this.Nombre = Nombre.Trim();
            this.Fecfac = Fecfac.Trim();
            this.ReferenciaInterna = ReferenciaInterna.Trim();
            this.Prefijosgs1 = Prefijosgs1.Trim();
            this.OrigenPrefijo = OrigenPrefijo.Trim();
            this.Orden = Orden;
            this.ClientesCodigo = ClientesCodigo;
          
            


        }
    }

}
