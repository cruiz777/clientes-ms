using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record PrefijosRequest
    {
        [JsonPropertyName("id_prefijos")]
        public long IdPrefijos { get; set; }

        public string? Codpre { get; set; }
        public DateOnly? Fecha { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string? Observacion { get; set; }
        public string? Digitos { get; set; }
        public bool? Estado { get; set; }
        public int? Control { get; set; }
        public int? Ngln { get; set; }
        public int? Bandera { get; set; }
        public string? Facturar { get; set; }
        public string? Codpro { get; set; }
        public string? Nombre { get; set; }
        public string? Fecfac { get; set; }
        public string? ReferenciaInterna { get; set; }
        public string? Prefijosgs1 { get; set; }
        public string? OrigenPrefijo { get; set; }
        public int? Orden { get; set; }
        public long? ClientesCodigo { get; set; }
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
