using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public record PrefijosResponse
    {
        [JsonPropertyName("id_prefijos")]
        public long IdPrefijos { get; set; }

        [JsonPropertyName("codpre")]
        public string Codpre { get; set; } = string.Empty;

        public DateOnly Fecha { get; set; }
        public DateTime FechaCierre { get; set; }
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
        public string TipoCliente { get; set; } = string.Empty;
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

        public List<GlnResponse> Glns { get; set; } = new();

        // Constructor por defecto
        public PrefijosResponse() { }

        // Constructor personalizado con todos los campos
        public PrefijosResponse(
            long idPrefijos, string codpre, DateOnly fecha, DateTime fechaCierre,
            string observacion, string digitos, bool estado, int control, int ngln, int bandera,
            string facturar, string codpro, string nombre, string fecfac, string referenciaInterna,
            string prefijosgs1, string origenPrefijo, int orden, long clientesCodigo,
            string nomcli, string gln,string tipoLocalizacion, string estadoEmpresa, string ruccli,
            DateOnly fecing, string zona, string tipoCliente, string grupoEmpresa, string grupoProducto,
            string representante, string direccion, string telefono, string web, string postal,
            string provincia, string canton, string ciudad, List<GlnResponse> glns)
        {
            IdPrefijos = idPrefijos;
            Codpre = codpre.Trim();
            Fecha = fecha;
            FechaCierre = fechaCierre;
            Observacion = observacion.Trim();
            Digitos = digitos.Trim();
            Estado = estado;
            Control = control;
            Ngln = ngln;
            Bandera = bandera;
            Facturar = facturar.Trim();
            Codpro = codpro.Trim();
            Nombre = nombre.Trim();
            Fecfac = fecfac.Trim();
            ReferenciaInterna = referenciaInterna.Trim();
            Prefijosgs1 = prefijosgs1.Trim();
            OrigenPrefijo = origenPrefijo.Trim();
            Orden = orden;
            ClientesCodigo = clientesCodigo;
            Nomcli = nomcli;
            Gln = gln;
            TipoLocalizacion = tipoLocalizacion;
            EstadoEmpresa = estadoEmpresa;
            Ruccli = ruccli;
            Fecing = fecing;
            Zona = zona;
            TipoCliente = tipoCliente;
            GrupoEmpresa = grupoEmpresa;
            GrupoProducto = grupoProducto;
            Representante = representante;
            Direccion = direccion;
            Telefono = telefono;
            Web = web;
            Postal = postal;
            Provincia = provincia;
            Canton = canton;
            Ciudad = ciudad;
            Glns = glns;
        }
    }
}
