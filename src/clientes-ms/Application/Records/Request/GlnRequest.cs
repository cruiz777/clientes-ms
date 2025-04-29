using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record GlnRequest
    {
        [JsonPropertyName("id_Gln")]
        public long IdGln { get; set; }
        [JsonPropertyName("id_prefijos")]
        public long IdPrefijos { get; set; }

        public long ClientesCodigo { get; set; }

        public string? Gln1 { get; set; }

        public long? IdTipoLocalizacion { get; set; }

        public string? GlnLatitud { get; set; }

        public string? GlnLongitud { get; set; }

        public long? IdPais { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Fax { get; set; }

        public string? Contacto { get; set; }

        public string? ContactoTel { get; set; }

        public string? Email { get; set; }

        public string? Web { get; set; }

        public string? Fda { get; set; }

        public string? Europa { get; set; }

        public string? GlnGlobal { get; set; }

        public DateOnly? GlnFecha { get; set; }

        public long? IdCiudad { get; set; }

        public string? GlnCodigopostal { get; set; }

        public string? GlnCelular { get; set; }

        public string? GlnContacto2 { get; set; }

        public string? GlnEmail2 { get; set; }

        public string? GlnTel2 { get; set; }

        public string? GlnContacto3 { get; set; }

        public string? GlnEmail3 { get; set; }

        public string? GlnTel3 { get; set; }

        public string? GlnFacturar { get; set; }

        public string? GlnCodpro { get; set; }

        public string? GlnNombre { get; set; }

        public string? GlnOtro1 { get; set; }

        public string? GlnOtro2 { get; set; }

        public string? GlnObs1 { get; set; }

        public string? GlnObs2 { get; set; }

        public string? GlnOrigenprefijo { get; set; }

        public string? GlnPrefijogs1 { get; set; }

        public string? GlnGlnp { get; set; }

        public string? GlnGlne { get; set; }

        public string? NombreLocalizacion { get; set; }

        public string? Observ { get; set; }

        public int Expprod { get; set; }

        public int Gs1ec { get; set; }

        public int Gs1latam { get; set; }

        public int Gas1org { get; set; }

        public int Google { get; set; }

        public string? Gs1otros { get; set; }

        public string? LongG { get; set; }

        public string? LongM { get; set; }

        public string? LongS { get; set; }

        public string? LongE { get; set; }

        public string? LatiG { get; set; }

        public string? LatiM { get; set; }

        public string? LatiS { get; set; }

        public string? LatiE { get; set; }

        public long? IdUsuario { get; set; }

        public GlnRequest() { }
        public GlnRequest(long IdGln,
 long IdPrefijos,
 long ClientesCodigo,
 string? Gln1,
 long? IdTipoLocalizacion,
 string? GlnLatitud,
 string? GlnLongitud,
 long? IdPais,
 string? Direccion,
 string? Telefono,
 string? Fax,
 string? Contacto,
 string? ContactoTel,
 string? Email,
 string? Web,
 string? Fda,
 string? Europa,
 string? GlnGlobal,
 DateOnly? GlnFecha,
 long? IdCiudad,
 string? GlnCodigopostal,
 string? GlnCelular,
 string? GlnContacto2,
 string? GlnEmail2,
 string? GlnTel2,
 string? GlnContacto3,
 string? GlnEmail3,
 string? GlnTel3,
 string? GlnFacturar,
 string? GlnCodpro,
 string? GlnNombre,
 string? GlnOtro1,
 string? GlnOtro2,
 string? GlnObs1,
 string? GlnObs2,
 string? GlnOrigenprefijo,
 string? GlnPrefijogs1,
 string? GlnGlnp,
 string? GlnGlne,
 string? NombreLocalizacion,
 string? Observ,

 int Expprod,

 int Gs1ec,

 int Gs1latam,

 int Gas1org,

 int Google,

 string? Gs1otros,

 string? LongG,

 string? LongM,

 string? LongS,

 string? LongE,

 string? LatiG,

 string? LatiM,

 string? LatiS,
        string? LatiE,

 long? IdUsuario)
        {
            this.IdPrefijos = IdPrefijos;
            this.ClientesCodigo = ClientesCodigo;
            this.Gln1 = Gln1;
            this.IdTipoLocalizacion = IdTipoLocalizacion;
            this.GlnLatitud = GlnLatitud;
            this.GlnLongitud = GlnLongitud;
            this.IdPais = IdPais;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Fax = Fax;
            this.Contacto = Contacto;
            this.ContactoTel = ContactoTel;
            this.Email = Email;
            this.Web = Web;
            this.Fda = Fda;
            this.Europa = Europa;
            this.GlnGlobal = GlnGlobal;
            this.GlnFecha = GlnFecha;
            this.IdCiudad = IdCiudad;
            this.GlnCodigopostal = GlnCodigopostal;
            this.GlnCelular = GlnCelular;
            this.GlnContacto2 = GlnContacto2;
            this.GlnEmail2 = GlnEmail2;
            this.GlnTel2 = GlnTel2;
            this.GlnContacto3 = GlnContacto3;
            this.GlnEmail3 = GlnEmail3;
            this.GlnTel3 = GlnTel3;
            this.GlnFacturar = GlnFacturar;
            this.GlnCodpro = GlnCodpro;
            this.GlnNombre = GlnNombre;
            this.GlnOtro1 = GlnOtro1;
            this.GlnOtro2 = GlnOtro2;
            this.GlnObs1 = GlnObs1;
            this.GlnObs2 = GlnObs2;
            this.GlnOrigenprefijo = GlnOrigenprefijo;
            this.GlnPrefijogs1 = GlnPrefijogs1;
            this.GlnGlnp = GlnGlnp;
            this.GlnGlne = GlnGlne;
            this.NombreLocalizacion = NombreLocalizacion;
            this.Observ = Observ;
            this.Expprod = Expprod;
            this.Gs1ec = Gs1ec;
            this.Gs1latam = Gs1latam;
            this.Gas1org = Gas1org;
            this.Google = Google;
            this.Gs1otros = Gs1otros;
            this.LongG = LongG;
            this.LongM = LongM;
            this.LongS = LongS;
            this.LongE = LongE;
            this.LatiG = LatiG;
            this.LatiM = LatiM;
            this.LatiS = LatiS;
            this.LatiE = LatiE;
            this.IdUsuario = IdUsuario;

        }
    }

}
