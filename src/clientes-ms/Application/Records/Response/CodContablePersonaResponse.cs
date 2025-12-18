// clientes_ms.Application/Records/Response/CodContablePersonaResponse.cs
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public record CodContablePersonaResponse
    {
        [JsonPropertyName("id_cod_contable")]
        public long IdCodContable { get; init; }

        [JsonPropertyName("id_persona")]
        public long IdPersona { get; init; }

        public CodContablePersonaResponse() { }

        public CodContablePersonaResponse(long idCodContable, long idPersona)
        {
            IdCodContable = idCodContable;
            IdPersona = idPersona;
        }
    }
}
