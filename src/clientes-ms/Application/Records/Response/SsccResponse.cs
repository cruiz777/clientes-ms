using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public record SsccResponse
    {
        [JsonPropertyName("id_sscc")]
        public long IdSscc { get; set; }

        [JsonPropertyName("id_prefijo")]
        public long IdPrefijo { get; set; }

        [JsonPropertyName("id_cliente")]
        public long IdCliente { get; set; }

        [JsonPropertyName("indicador")]
        public byte Indicador { get; set; }

        [JsonPropertyName("serial")]
        public string Serial { get; set; } = string.Empty;

        [JsonPropertyName("digito_control")]
        public string DigitoControl { get; set; } = string.Empty;

        [JsonPropertyName("sscc_completo")]
        public string SsccCompleto { get; set; } = string.Empty;

        [JsonPropertyName("serie")]
        public bool? Serie { get; set; }

        [JsonPropertyName("secuencia_inicio")]
        public int? SecuenciaInicio { get; set; }

        [JsonPropertyName("secuencia_fin")]
        public int? SecuenciaFin { get; set; }

        [JsonPropertyName("total_generado")]
        public int? TotalGenerado { get; set; }

        [JsonPropertyName("producto_codificado")]
        public string? ProductoCodificado { get; set; }

        [JsonPropertyName("estado")]
        public bool? Estado { get; set; }

        [JsonPropertyName("usuario")]
        public string? Usuario { get; set; }

        [JsonPropertyName("fecha_creacion")]
        public DateTime? FechaCreacion { get; set; }

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
