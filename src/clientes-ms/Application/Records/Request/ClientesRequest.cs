using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record ClientesRequest
    {
      
        
        public long? ClientesCodigo { get; set; } 
        public string? Nomcli { get; set; } = string.Empty;
        public string? Dircli { get; set; } = string.Empty;
        public string? Concli { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Telefono { get; set; } = string.Empty;
        public string? Telefono1 { get; set; } = string.Empty;
        public string? RazonSocial { get; set; } = string.Empty;
        public string? Fax { get; set; } = string.Empty;
        public string? Ruc { get; set; } = string.Empty;
        public DateOnly? Fecing { get; set; }
        public DateOnly? Fecnac { get; set; }
        public DateOnly? Fecfac1 { get; set; }
        public DateOnly? Fecfac2 { get; set; }
        public DateOnly? Fecfac3 { get; set; }
        public DateOnly? Fecfac4 { get; set; }
        public DateOnly? Fecfac5 { get; set; }
        public string Marca1 { get; set; } = string.Empty;
        public string Marca2 { get; set; } = string.Empty;
        public string Marca3 { get; set; } = string.Empty;
        public string Marca4 { get; set; } = string.Empty;
        public string Marca5 { get; set; } = string.Empty;
        public string Codcue { get; set; } = string.Empty;
        public string Hello { get; set; } = string.Empty;
        public double? Desde { get; set; }
        public DateTime? Fechtre { get; set; } = DateTime.MinValue;
        public string? Web { get; set; } = string.Empty;
        public decimal? Saldo { get; set; }
        public string? Fecfac { get; set; } = string.Empty;
        public string? Ciudad { get; set; } = string.Empty;
        public string? Obs { get; set; } = string.Empty;
        public short? Delestado { get; set; }
        public string? Genero { get; set; } = string.Empty;
        public string? Infcamahabitacion { get; set; } = string.Empty;
        public long? EmpresaCodigo { get; set; }
        public short? Seguimiento { get; set; }
        public DateOnly? Fechaactinact { get; set; }
        public long? IdEstadoEmpresa { get; set; }
        public int? Formatodocumento { get; set; }
        public int? Imprimeobstramite { get; set; }
        public long? IdTipoCliente { get; set; }
        public long? IdGrupoProducto { get; set; }
        public long? IdPersona { get; set; }
        public string? CodigoPostal { get; set; } = string.Empty;
        public string? CodigoPostal2 { get; set; } = string.Empty;
        public long? IdVendedor { get; set; }
        public long? IdCiudad { get; set; }
        public long? IdZona { get; set; }
        public long? IdGrupoEmpresa { get; set; }
        public string? Representante { get; set; } = string.Empty;
        [JsonPropertyName("fecCeseAct")]
        public string? FechaCeseAct { get; set; }

        [JsonPropertyName("motivoCeseAct")]
        public string? MotivoCeseAct { get; set; }

        [JsonIgnore]
        public DateOnly? FechaCeseActParsed =>
            DateOnly.TryParse(FechaCeseAct, out var date) ? date : null;

        public ClientesRequest() { }
        public ClientesRequest(long ClientesCodigo ,

     string Nomcli,

     string Dircli,

     string Concli,

     string Email,

     string Telefono,

     string Telefono1,

     string RazonSocial,

     string Fax,

     string Ruc,

     DateOnly Fecing,

     DateOnly Fecnac,
     DateOnly? FechaCeseAct,

     DateOnly Fecfac1,

     DateOnly Fecfac2,

     DateOnly Fecfac3,

     DateOnly Fecfac4,

     DateOnly Fecfac5,
     string? MotivoCeseAct,
     string Marca1,

     string Marca2,

     string Marca3,

     string Marca4,

     string Marca5,

     string Codcue,

     string Hello,

     double Desde,

    DateTime Fechtre,

     string Web,

     decimal Saldo,

     string Fecfac,

     string Ciudad,

     string Obs,

     short Delestado,

     string Genero,

     string Infcamahabitacion,

     long EmpresaCodigo,

     short Seguimiento,

     DateOnly Fechaactinact,

     long IdEstadoEmpresa,

     int Formatodocumento,

     int Imprimeobstramite,

     long IdTipoCliente,

     long IdGrupoProducto,

     long IdPersona,

     string CodigoPostal,

     string CodigoPostal2,

     long IdVendedor,

     long IdCiudad,

     long IdZona,

     long IdGrupoEmpresa,

     string Representante)
        {
            this.ClientesCodigo = ClientesCodigo;
            this.Nomcli = Nomcli;
            this.Dircli = Dircli;
            this.Concli = Concli;
            this.Email = Email;
            this.Telefono = Telefono;
            this.Telefono1 = Telefono1;
            this.RazonSocial = RazonSocial;
            this.Fax = Fax;
            this.Ruc = Ruc;
            this.Fecing = Fecing;
            this.Fecnac = Fecnac;
            this.FechaCeseAct = FechaCeseAct?.ToString("yyyy-MM-dd");
            this.MotivoCeseAct = MotivoCeseAct;
            this.Fecfac1 = Fecfac1;
            this.Fecfac2 = Fecfac2;
            this.Fecfac3 = Fecfac3;
            this.Fecfac4 = Fecfac4;
            this.Fecfac5 = Fecfac5;
            this.Marca1 = Marca1;
            this.Marca2 = Marca2;
            this.Marca3 = Marca3;
            this.Marca4 = Marca4;
            this.Marca5 = Marca5;
            this.Codcue = Codcue;
            this.Hello = Hello;
            this.Desde = Desde;
            this.Fechtre = Fechtre;
            this.Web = Web;
            this.Saldo = Saldo;
            this.Fecfac = Fecfac;
            this.Ciudad = Ciudad;
            this.Obs = Obs;
            this.Delestado = Delestado;
            this.Genero = Genero;
            this.Infcamahabitacion = Infcamahabitacion;
            this.EmpresaCodigo = EmpresaCodigo;
            this.Seguimiento = Seguimiento;
            this.Fechaactinact = Fechaactinact;
            this.IdEstadoEmpresa = IdEstadoEmpresa;
            this.Formatodocumento = Formatodocumento;
            this.Imprimeobstramite = Imprimeobstramite;
            this.IdTipoCliente = IdTipoCliente;
            this.IdGrupoProducto = IdGrupoProducto;
            this.IdPersona = IdPersona;
            this.CodigoPostal = CodigoPostal;
            this.CodigoPostal2 = CodigoPostal2;
            this.IdVendedor = IdVendedor;
            this.IdCiudad = IdCiudad;
            this.IdZona = IdZona;
            this.IdGrupoEmpresa = IdGrupoEmpresa;
            this.Representante = Representante;



        }
    }

}
