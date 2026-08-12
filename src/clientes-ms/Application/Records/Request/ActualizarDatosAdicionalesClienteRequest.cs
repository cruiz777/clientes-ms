namespace clientes_ms.Application.Records.Request
{
    public class ActualizarDatosAdicionalesClienteRequest
    {
        public long ClientesCodigo { get; set; }

        public bool CheckPrefijo { get; set; }

        public bool CheckGuia { get; set; }

        public bool CheckOtros { get; set; }

      
    }
}