using MediatR;
using clientes_ms.Application.Records.Response;

public class DeleteAuditoriaPrefijosCommand : IRequest<ApiResponse<bool>>
{
    public long IdAuditoriaPrefijos { get; set; }

    public DeleteAuditoriaPrefijosCommand(long idAuditoriaPrefijos)
    {
        IdAuditoriaPrefijos = idAuditoriaPrefijos;
    }
}
