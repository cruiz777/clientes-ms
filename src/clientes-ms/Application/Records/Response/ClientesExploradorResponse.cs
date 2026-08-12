using System;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public class ClientesExploradorResponse
    {
        [JsonPropertyName("clientes_codigo")]
        public long ClientesCodigo { get; set; }

        [JsonPropertyName("nomcli")]
        public string NomCli { get; set; } = string.Empty;

        [JsonPropertyName("dircli")]
        public string Dircli { get; set; } = string.Empty;

        [JsonPropertyName("ruc")]
        public string Ruc { get; set; } = string.Empty;

        [JsonPropertyName("fecing")]
        public DateOnly? Fecing { get; set; }

        [JsonPropertyName("zonaReferencia")]
        public string ZonaReferencia { get; set; } = string.Empty;

        [JsonPropertyName("estadoNombre")]
        public string EstadoNombre { get; set; } = string.Empty;

        [JsonPropertyName("prefijo")]
        public string Prefijo { get; set; } = string.Empty;

        [JsonPropertyName("representante")]
        public string Representante { get; set; } = string.Empty;

        [JsonPropertyName("telefono")]
        public string Telefono { get; set; } = string.Empty;

        [JsonPropertyName("tipoCliente")]
        public string TipoCliente { get; set; } = string.Empty;

        [JsonPropertyName("grupoEmpresa")]
        public string GrupoEmpresa { get; set; } = string.Empty;

        /*
         * Nuevas columnas del explorador
         */
        [JsonPropertyName("nPrefijo")]
        public int NPrefijo { get; set; }

        [JsonPropertyName("checkPrefijo")]
        public bool CheckPrefijo { get; set; }

        [JsonPropertyName("checkGuia")]
        public bool CheckGuia { get; set; }

        [JsonPropertyName("checkOtros")]
        public bool CheckOtros { get; set; }
    }
}