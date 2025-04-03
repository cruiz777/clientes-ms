using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record ZonaRequest
    {
        [JsonPropertyName("id_Zona")]
        public long IdZona { get; set; }
        [JsonPropertyName("referencia")]
        public string Referencia { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public long EmpresaCodigo { get; set; } = 0;

        public ZonaRequest() { }
        public ZonaRequest(long IdZona, string Referencia,string Nombre,string Numero,long EmpresaCodigo)
        {
            this.IdZona = IdZona;
            this.Referencia = Referencia.Trim();
            this.Nombre = Nombre.Trim();
            this.Numero = Numero.Trim();

        }
    }

}
