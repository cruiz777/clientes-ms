using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record GrupoEmpresaRequest
    {
        [JsonPropertyName("id_grupo_empresa")]
        public long IdGrupoEmpresa { get; set; }
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; } = string.Empty;

        public string? Nombre { get; set; } = string.Empty;

        public double? Inscripcion { get; set; } = 0;
        public double? Asignacion { get; set; } = 0;
        public double? Mantenimiento { get; set; } = 0;

        public DateOnly? Fecha { get; set; }

        public string? ProductoInscripcion { get; set; } = string.Empty;
        public string? ProductoMantenimiento { get; set; } = string.Empty;
        public string? ProductoAsignacion { get; set; } = string.Empty;
        public double? AsignacionDolar { get; set; } = 0;
        public double? MantenimientoDolar { get; set; } = 0;
        public double? InscripcionDolar { get; set; } = 0;
        public double? ValorAnual { get; set; } = 0;

        public bool Estado { get; set; } = false;
        public GrupoEmpresaRequest() { }
        public GrupoEmpresaRequest(long IdGrupoEmpresa, string Codigo, string Nombre, double Inscripcion, double Asignacion,
double Mantenimiento, DateOnly Fecha, string ProductoInscripcion, string ProductoMantenimiento,
string ProductoAsignacion, double AsignacionDolar, double MantenimientoDolar, double InscripcionDolar, double ValorAnual,bool Estado)
        {
            this.IdGrupoEmpresa = IdGrupoEmpresa;
            this.Codigo = Codigo.Trim();
            this.Nombre = Nombre.Trim();
            this.Inscripcion = Inscripcion;
            this.Asignacion = Asignacion;
            this.Mantenimiento = Mantenimiento;
            this.Fecha = Fecha;
            this.ProductoInscripcion = ProductoInscripcion.Trim();
            this.ProductoMantenimiento = ProductoMantenimiento.Trim();
            this.ProductoAsignacion = ProductoAsignacion.Trim();
            this.AsignacionDolar = AsignacionDolar;
            this.MantenimientoDolar = MantenimientoDolar;
            this.InscripcionDolar = InscripcionDolar;
            this.ValorAnual = ValorAnual;
            this.Estado = Estado;

        }
    }

}
