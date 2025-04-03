using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record EstadoEmpresaResponse
    {
        [JsonPropertyName("id")]
        public long IdEstadoEmpresa { get; set; }
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; } = string.Empty;
        public DateOnly Fecha {  get; set; }
        public long EmpresaCodigo { get; set; } = 0;
        public EstadoEmpresaResponse() { }
        public EstadoEmpresaResponse(long id_EstadoEmpresa, string Nombre,DateOnly Fecha,long EmpresaCodigo)
        {
            this.IdEstadoEmpresa = id_EstadoEmpresa;
            this.Nombre = Nombre.Trim();
            this.Fecha = Fecha;
            this.EmpresaCodigo = EmpresaCodigo;
            

        }
    }
}
