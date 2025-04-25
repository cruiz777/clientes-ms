using clientes_ms.Application.DTOs.NumeroControl;
using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.DTOs.NumeroControl
{
    public class UpdateNumeroControlDto
    {
        public string Numcon { get; set; } = string.Empty;
        public bool Ocupado { get; set; }
        
    }
}
