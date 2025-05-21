using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public record ClienteDatosAdicionalesResponse
    {
        [JsonPropertyName("id_datos_adicionales")]
        public long IdDatosAdicionales { get; init; }

        [JsonPropertyName("expprod")]
        public bool? Expprod { get; init; }

        [JsonPropertyName("vendeus")]
        public bool? Vendeus { get; init; }

        [JsonPropertyName("medico")]
        public bool? Medico { get; init; }

        [JsonPropertyName("gs1ec")]
        public bool? Gs1ec { get; init; }

        [JsonPropertyName("instagram")]
        public bool? Instagram { get; init; }

        [JsonPropertyName("facebook")]
        public bool? Facebook { get; init; }

        [JsonPropertyName("web")]
        public bool? Web { get; init; }

        [JsonPropertyName("clientes_codigo")]
        public long? ClientesCodigo { get; init; }

        [JsonPropertyName("prefijo")]
        public bool? Prefijo { get; init; }

        [JsonPropertyName("guia")]
        public bool? Guia { get; init; }

        [JsonPropertyName("estado")]
        public bool? Estado { get; init; }

        public ClienteDatosAdicionalesResponse() { }

        public ClienteDatosAdicionalesResponse(
            long idDatosAdicionales,
            bool? expprod,
            bool? vendeus,
            bool? medico,
            bool? gs1ec,
            bool? instagram,
            bool? facebook,
            bool? web,
            long? clientesCodigo,
            bool? prefijo,
            bool? guia,
            bool? estado)
        {
            IdDatosAdicionales = idDatosAdicionales;
            Expprod = expprod;
            Vendeus = vendeus;
            Medico = medico;
            Gs1ec = gs1ec;
            Instagram = instagram;
            Facebook = facebook;
            Web = web;
            ClientesCodigo = clientesCodigo;
            Prefijo = prefijo;
            Guia = guia;
            Estado = estado;
        }
    }
}
