using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
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

        public string? Origen { get; set; }

        public string? Destino { get; set; }
        public string? Usuario { get; set; }
        public string? Prefijo { get; set; }

        public AuditoriaTransferenciaResponse() { }
        public AuditoriaTransferenciaResponse(long IdTraferenciaPrefijo, long ClientesCodigoOrigen, long ClientesCodigoDestino, DateTime Fecha, long IdPrefijos, string Tipo, long IdUsuario, string origen, string destino, string usuario, string prefijo)
        {
            this.IdTraferenciaPrefijo = IdTraferenciaPrefijo;
            this.ClientesCodigoOrigen = ClientesCodigoOrigen;
            this.ClientesCodigoDestino = ClientesCodigoDestino;
            this.Fecha = Fecha;
            this.IdPrefijos = IdPrefijos;
            this.IdUsuario = IdUsuario;
            this.Tipo = Tipo;
            this.Origen = origen;
            this.Destino = destino;
            this.Usuario = usuario;
            this.Prefijo = prefijo;



        }
    }
}
