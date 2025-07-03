using clientes_ms.Application.Records.Response;
using MediatR;
using MicroservicesTemplate.Domain;

namespace clientes_ms.Application.Commands.Ssccs;

public class UpdateSsccClientePorPrefijoCommand : IRequest<ApiResponse<bool>>
{
    public long IdPrefijo { get; set; }
    public long NuevoIdCliente { get; set; }

    public UpdateSsccClientePorPrefijoCommand(long idPrefijo, long nuevoIdCliente)
    {
        IdPrefijo = idPrefijo;
        NuevoIdCliente = nuevoIdCliente;
    }
}
