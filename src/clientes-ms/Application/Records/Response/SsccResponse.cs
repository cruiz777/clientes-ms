using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public record SsccResponse
    {
        [JsonPropertyName("id_sscc")]
        public long IdSscc { get; init; }

        [JsonPropertyName("id_prefijo")]
        public long IdPrefijo { get; init; }

        [JsonPropertyName("id_cliente")]
        public long IdCliente { get; init; }

        [JsonPropertyName("indicador")]
        public byte Indicador { get; init; }

        [JsonPropertyName("serial")]
        public string Serial { get; init; } = string.Empty;

        [JsonPropertyName("digito_control")]
        public string DigitoControl { get; init; } = string.Empty;

        [JsonPropertyName("sscc_completo")]
        public string SsccCompleto { get; init; } = string.Empty;

        [JsonPropertyName("serie")]
        public bool? Serie { get; init; }

        [JsonPropertyName("secuencia_inicio")]
        public int? SecuenciaInicio { get; init; }

        [JsonPropertyName("secuencia_fin")]
        public int? SecuenciaFin { get; init; }

        [JsonPropertyName("total_generado")]
        public int? TotalGenerado { get; init; }

        [JsonPropertyName("producto_codificado")]
        public string? ProductoCodificado { get; init; }

        [JsonPropertyName("estado")]
        public bool? Estado { get; init; }

        [JsonPropertyName("usuario")]
        public string? Usuario { get; init; }

        [JsonPropertyName("fecha_creacion")]
        public DateTime? FechaCreacion { get; init; }

        public SsccResponse() { }

        public SsccResponse(
            long idSscc,
            long idPrefijo,
            long idCliente,
            byte indicador,
            string serial,
            string digitoControl,
            string ssccCompleto,
            bool? serie,
            int? secuenciaInicio,
            int? secuenciaFin,
            int? totalGenerado,
            string? productoCodificado,
            bool? estado,
            string? usuario,
            DateTime? fechaCreacion)
        {
            IdSscc = idSscc;
            IdPrefijo = idPrefijo;
            IdCliente = idCliente;
            Indicador = indicador;
            Serial = serial;
            DigitoControl = digitoControl;
            SsccCompleto = ssccCompleto;
            Serie = serie;
            SecuenciaInicio = secuenciaInicio;
            SecuenciaFin = secuenciaFin;
            TotalGenerado = totalGenerado;
            ProductoCodificado = productoCodificado;
            Estado = estado;
            Usuario = usuario;
            FechaCreacion = fechaCreacion;
        }
    }
}
