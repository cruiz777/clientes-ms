using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record AuditoriaTransferenciaRequest
    {
        [JsonPropertyName("id_traferencia_prefijo")]
        public long IdTraferenciaPrefijo { get; set; }

        public long? ClientesCodigoOrigen { get; set; }

        public long? ClientesCodigoDestino { get; set; }

        public DateTime? Fecha { get; set; }

        public long? IdPrefijos { get; set; }

        public string? Tipo { get; set; }

        public long? IdUsuario { get; set; }

     

        public AuditoriaTransferenciaRequest() { }
        public AuditoriaTransferenciaRequest(long IdTraferenciaPrefijo, long ClientesCodigoOrigen, long ClientesCodigoDestino, DateTime Fecha, long IdPrefijos, string Tipo, long IdUsuario)
        {
            this.IdTraferenciaPrefijo = IdTraferenciaPrefijo;
            this.ClientesCodigoOrigen = ClientesCodigoOrigen;
            this.ClientesCodigoDestino= ClientesCodigoDestino;
            this.Fecha = Fecha;
            this.IdPrefijos = IdPrefijos;
            this.IdUsuario = IdUsuario;
           



        }
    }

}
