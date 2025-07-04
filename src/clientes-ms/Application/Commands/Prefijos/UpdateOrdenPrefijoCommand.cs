using MediatR;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Commands.Prefijos
{
    public class UpdateOrdenPrefijoCommand : IRequest<ApiResponse<bool>>
    {
        public int IdPrefijos { get; set; }
        public int Orden { get; set; }

        public UpdateOrdenPrefijoCommand(int idPrefijos, int orden)
        {
            IdPrefijos = idPrefijos;
            Orden = orden;
        }
    }
}
