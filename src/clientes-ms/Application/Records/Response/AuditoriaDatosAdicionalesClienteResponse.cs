namespace clientes_ms.Application.Records.Response
{
    public class AuditoriaDatosAdicionalesClienteResponse
    {
        public long IdAuditoria { get; set; }

        public int ClientesCodigo { get; set; }

        public string? NombreCliente { get; set; }

        public string? Campo { get; set; }

        public bool ValorAnterior { get; set; }

        public bool ValorNuevo { get; set; }

        public long? IdUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public string? Usuario { get; set; }
    }
}