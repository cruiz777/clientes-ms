using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    public record SsccRequest
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("id_prefijo")]
        public long IdPrefijo { get; set; }

        [JsonPropertyName("id_cliente")]
        public long IdCliente { get; set; }

        [JsonPropertyName("indicador")]
        public byte Indicador { get; set; }

        [JsonPropertyName("serial")]
        public string Serial { get; set; } = string.Empty;

        [JsonPropertyName("producto_codificado")]
        public string? ProductoCodificado { get; set; }

        [JsonPropertyName("serie")]
        public bool? Serie { get; set; }
        [JsonPropertyName("cantidad_codigos")]
        public int? CantidadCodigos { get; set; }

        [JsonPropertyName("secuencia_inicio")]
        public int? SecuenciaInicio { get; set; }

        [JsonPropertyName("secuencia_fin")]
        public int? SecuenciaFin { get; set; }
        
        [JsonPropertyName("usuario")]
        public string? Usuario { get; set; }

        public SsccRequest() { }

        public SsccRequest(long? id, long idPrefijo, long idCliente, byte indicador, string serial, string? productoCodificado, bool? serie, int? secuenciaInicio, int? secuenciaFin, string? usuario)
        {
            Id = id;
            IdPrefijo = idPrefijo;
            IdCliente = idCliente;
            Indicador = indicador;
            Serial = serial.Trim();
            ProductoCodificado = productoCodificado?.Trim();
            Serie = serie;
            SecuenciaInicio = secuenciaInicio;
            SecuenciaFin = secuenciaFin;
            Usuario = usuario?.Trim();
        }
    }
}
