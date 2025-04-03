using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record ExampleResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
     
        [JsonPropertyName("status")]
        public bool Status { get; set; } = true;


        public ExampleResponse() { }
        public ExampleResponse(long id, string name, bool status)
        {
            this.Id = id;
            this.Name = name.Trim();
            this.Status = status;
        }
    }
}
