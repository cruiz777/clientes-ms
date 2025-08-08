namespace clientes_ms.Application.Records.Response
{
    public class ClientesResumenDto
    {
        public long ClientesCodigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string CodigosPrefijo { get; set; } = string.Empty;
    }
}
