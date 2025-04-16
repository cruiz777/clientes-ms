//using clientes_ms.Domain.Entities;
//using System.Text.Json.Serialization;

//namespace clientes_ms.Application.Records.Response
//{

//    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
//    public record CiudadesResponse
//    {
//        [JsonPropertyName("id")]
//        public long IdCanton { get; set; }
//        [JsonPropertyName("Referencia")]
//        public string Referencia { get; set; } = string.Empty;
//        public string Nombre { get; set; } = string.Empty;
//        public long IdProvincia { get; set; } = 0;
//        public CiudadesResponse() { }
//        public CiudadesResponse(long id_Canton, string Referencia,string Nombre,long IdProvincia)
//        {
//            this.IdCanton = id_Canton;
//            this.Referencia = Referencia.Trim();
//            this.Nombre = Nombre.Trim();
//            this.IdProvincia = IdProvincia;

//        }
//    }
//}
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public record CiudadesResponse
    {
        [JsonPropertyName("id_ciudad")]
        public long IdCiudad { get; init; }

        [JsonPropertyName("codigo")]
        public string Codigo { get; init; } = string.Empty;

        [JsonPropertyName("ciudad")]
        public string Ciudad { get; init; } = string.Empty;

        [JsonPropertyName("canton")]
        public string Canton { get; init; } = string.Empty;

        [JsonPropertyName("provincia")]
        public string Provincia { get; init; } = string.Empty;
    }
}
