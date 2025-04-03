using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record EstadoEmpresaRequest
    {
        [JsonPropertyName("id_EstadoEmpresa")]
        public long IdEstadoEmpresa { get; set; }
        [JsonPropertyName("nombre")]
       public string Nombre { get; set; } = string.Empty;

        public DateOnly Fecha { get; set; }
        public long EmpresaCodigo { get; set; } = 0;
        public EstadoEmpresaRequest() { }
        public EstadoEmpresaRequest(long IdEstadoEmpresa, string Nombre, DateOnly Fecha, long EmpresaCodigo)
        {
            this.IdEstadoEmpresa = IdEstadoEmpresa;
            this.Nombre = Nombre.Trim();
            this.Fecha = Fecha;
            this.EmpresaCodigo = EmpresaCodigo;

        }
    }

}
