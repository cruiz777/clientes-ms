namespace clientes_ms.Application.DTOs.Clientes
{
    public class SriApiResponse
    {
        public bool ok { get; set; }
        public List<ConsultaSri> consulta { get; set; } = new();
    }

    public class ConsultaSri
    {
        public string numeroRuc { get; set; } = string.Empty;
        public string razonSocial { get; set; } = string.Empty;
        public string estadoContribuyenteRuc { get; set; } = string.Empty;
        public string actividadEconomicaPrincipal { get; set; } = string.Empty;
        public string tipoContribuyente { get; set; } = string.Empty;
        public string regimen { get; set; } = string.Empty;
        public string? categoria { get; set; }
        public string obligadoLlevarContabilidad { get; set; } = string.Empty;
        public string agenteRetencion { get; set; } = string.Empty;
        public string contribuyenteEspecial { get; set; } = string.Empty;

        public InformacionFechasContribuyente informacionFechasContribuyente { get; set; } 
        public List<RepresentanteLegal>? representantesLegales { get; set; }
        public string? motivoCancelacionSuspension { get; set; }

        public string contribuyenteFantasma { get; set; } = string.Empty;
        public string transaccionesInexistente { get; set; } = string.Empty;
    }

    public class InformacionFechasContribuyente
    {
        public string? fechaInicioActividades { get; set; }
        public string? fechaCese { get; set; }
        public string? fechaReinicioActividades { get; set; }
        public string? fechaActualizacion { get; set; }
    }

    public class RepresentanteLegal
    {
        public string nombre { get; set; } = string.Empty;
    }

}
