namespace clientes_ms.Application.Records.Request
{
    public class AuditoriaDatoAdicionalClienteRequest
    {
        public int ClientesCodigo { get; set; }

        public string? NombreCliente { get; set; }

        public string Campo { get; set; } = string.Empty;

        public bool ValorAnterior { get; set; }

        public bool ValorNuevo { get; set; }

        public long? IdUsuario { get; set; }
    }
}