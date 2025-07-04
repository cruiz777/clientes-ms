using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public record AuditoriaTransferenciaResponse
    {
        [JsonPropertyName("id_traferencia_prefijo")]
        public long IdTraferenciaPrefijo { get; set; }

        public long? ClientesCodigoOrigen { get; set; }
        public long? ClientesCodigoDestino { get; set; }
        public DateTime? Fecha { get; set; }
        public long? IdPrefijos { get; set; }
        public string? Tipo { get; set; }
        public long? IdUsuario { get; set; }

        public string? Origen { get; set; }          // Empresa anterior
        public string? RucOrigen { get; set; }       // RUC anterior
        public string? Destino { get; set; }         // Empresa actual
        public string? RucDestino { get; set; }      // RUC actual
        public string? Usuario { get; set; }
        public string? Prefijo { get; set; }

        public AuditoriaTransferenciaResponse() { }

        public AuditoriaTransferenciaResponse(
            long idTraferenciaPrefijo,
            long clientesCodigoOrigen,
            long clientesCodigoDestino,
            DateTime fecha,
            long idPrefijos,
            string tipo,
            long idUsuario,
            string origen,
            string destino,
            string usuario,
            string prefijo,
            string rucOrigen,
            string rucDestino)
        {
            IdTraferenciaPrefijo = idTraferenciaPrefijo;
            ClientesCodigoOrigen = clientesCodigoOrigen;
            ClientesCodigoDestino = clientesCodigoDestino;
            Fecha = fecha;
            IdPrefijos = idPrefijos;
            Tipo = tipo;
            IdUsuario = idUsuario;
            Origen = origen;
            RucOrigen = rucOrigen;
            Destino = destino;
            RucDestino = rucDestino;
            Usuario = usuario;
            Prefijo = prefijo;
        }
    }
}
