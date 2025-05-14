using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record PrefijosResponse
    {
        [JsonPropertyName("id_prefijos")]
        public long IdPrefijos { get; set; }
        [JsonPropertyName("codpre")]
        public string Codpre { get; set; } = string.Empty;

        public DateOnly Fecha { get; set; } =DateOnly.MinValue;

        public DateTime FechaCierre { get; set; } = DateTime.MinValue;
        public string Observacion { get; set; } = string.Empty;
        public string Digitos { get; set; } = string.Empty;
        public bool Estado { get; set; } = false;
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
        public int Orden { get; set; } = 0;

        public long ClientesCodigo { get; set; } = 0;

        public string Nomcli { get; set; } = string.Empty;
        public string Gln { get; set; } = string.Empty;
        public string TipoLocalizacion { get; set; } = string.Empty;

        public string EstadoEmpresa { get; set; } = string.Empty;
        public string Ruccli { get; set; } = string.Empty;
        public DateOnly Fecing { get; set; } = DateOnly.MinValue;
        public string Zona { get; set; } = string.Empty;

        public string TipoCliente {  get; set; } = string.Empty;
        public string GrupoEmpresa { get; set; } = string.Empty;
        public string GrupoProducto { get; set; } = string.Empty;
        public string Representante { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Web { get; set; } = string.Empty;
        public string Postal { get; set; } = string.Empty;  
        public string Provincia { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;



        public PrefijosResponse() { }
        public PrefijosResponse(
 long IdPrefijos, string Codpre,  DateOnly Fecha,
 DateTime FechaCierre, string Observacion, string Digitos,
 bool Estado, int Control, int Ngln,
 int Bandera, string Facturar, string Codpro,
 string Nombre, string Fecfac, string ReferenciaInterna,
 string Prefijosgs1, string OrigenPrefijo, int Orden,long ClientesCodigo)
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
            this.OrigenPrefijo = Prefijosgs1.Trim();
            this.Orden = Orden;
            this.ClientesCodigo = ClientesCodigo;
            this.Nomcli=Nomcli;
            this.Gln = Gln;
            this.TipoLocalizacion=TipoLocalizacion;
            this.Fecing=Fecing;
            this.Representante = Representante;
            this.Ruccli=Ruccli;
            this.Zona = Zona;
            this.GrupoProducto = GrupoProducto;
            this.GrupoProducto = GrupoEmpresa;

        }
    }
}
