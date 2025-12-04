using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response;

public record NumeroReservadoResponse
{
    [JsonPropertyName("numeroAsignado")]
    public string NumeroAsignado { get; init; } = string.Empty;

    [JsonPropertyName("siguienteNumero")]
    public string SiguienteNumero { get; init; } = string.Empty;

    public NumeroReservadoResponse() { }

    public NumeroReservadoResponse(string numeroAsignado, string siguienteNumero)
    {
        NumeroAsignado = numeroAsignado;
        SiguienteNumero = siguienteNumero;
    }
}