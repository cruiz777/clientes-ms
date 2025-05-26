using clientes_ms.Domain.Entities;
using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{

    //Igual que en el apartado de Request, pero ahora con la respuesta que necesitas obtener
    public record HistorialClienteResponse
    {
        [JsonPropertyName("id_historial_cliente")]
        public long IdHistorialCliente { get; init; }

        [JsonPropertyName("id_usuario")]
        public long IdUsuario { get; set; } = 0;
        [JsonPropertyName("nombre_usuario")]
        public string NombreUsuario { get; set; } = string.Empty;
        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;
        [JsonPropertyName("clientes_codigo")]
        public long ClientesCodigo { get; init; } = 0;

        [JsonPropertyName("cliente")]
        public string Cliente { get; init; } = string.Empty;

        [JsonPropertyName("tabla")]
        public string Tabla { get; init; } = string.Empty;

        [JsonPropertyName("tipo_accion")]
        public string TipoAccion { get; init; } = string.Empty;

        [JsonPropertyName("id_empresa")]
        public long IdEmpresa { get; init; } = 0;


        public HistorialClienteResponse() { }
        public HistorialClienteResponse(
     long id_historial_cliente,
     long id_usuario,
     string nombre_usuario,
     DateTime fecha,
     string descripcion,
     long clientes_codigo,
     string cliente,
     string tabla,
     string tipo_accion,
     long id_empresa
            
            )
        {
            this.IdHistorialCliente = id_historial_cliente;
            this.IdUsuario = id_usuario;
            this.NombreUsuario = nombre_usuario;
            this.Fecha = fecha; // ← aquí estaba el error
            this.Descripcion = descripcion?.Trim() ?? string.Empty;
            this.ClientesCodigo = clientes_codigo;
            this.Cliente = cliente;
            this.Tabla = tabla;
            this.TipoAccion = tipo_accion;
            this.IdEmpresa = id_empresa;
        }

    }
}
