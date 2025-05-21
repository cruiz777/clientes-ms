using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    public record ClienteDatosAdicionalesRequest
    {
        [JsonPropertyName("id_datos_adicionales")]
        public long IdDatosAdicionales { get; set; }

        [JsonPropertyName("expprod")]
        public bool? Expprod { get; set; }

        [JsonPropertyName("vendeus")]
        public bool? Vendeus { get; set; }

        [JsonPropertyName("medico")]
        public bool? Medico { get; set; }

        [JsonPropertyName("gs1ec")]
        public bool? Gs1ec { get; set; }

        [JsonPropertyName("instagram")]
        public bool? Instagram { get; set; }

        [JsonPropertyName("facebook")]
        public bool? Facebook { get; set; }

        [JsonPropertyName("web")]
        public bool? Web { get; set; }

        [JsonPropertyName("clientes_codigo")]
        public long? ClientesCodigo { get; set; }

        [JsonPropertyName("prefijo")]
        public bool? Prefijo { get; set; }

        [JsonPropertyName("guia")]
        public bool? Guia { get; set; }

        [JsonPropertyName("estado")]
        public bool? Estado { get; set; }

        public ClienteDatosAdicionalesRequest() { }

        public ClienteDatosAdicionalesRequest(
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
