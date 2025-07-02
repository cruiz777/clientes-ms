using System.Text.Json.Serialization;
using MediatR;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Commands;

public record UpdateCuponEstadoCommand : IRequest<ApiResponse<bool>>
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("estado")]
    public bool Estado { get; set; }

    public UpdateCuponEstadoCommand() { }

    public UpdateCuponEstadoCommand(long id, bool estado)
    {
        Id = id;
        Estado = estado;
    }
}
