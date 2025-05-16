using clientes_ms.Application.DTOs.Clientes;
using clientes_ms.Application.Options;
using clientes_ms.Domain.Interfaces.IDomainServices;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

public class ClienteDomainService : IClienteDomainService
{
    private readonly HttpClient _http;
    private readonly ApisExternasOptions _options;

    public ClienteDomainService(HttpClient http, IOptions<ApisExternasOptions> options)
    {
        _http = http;
        _options = options.Value;
    }

    public async Task<ClienteValidadoDTO?> ValidarClienteDesdeSriAsync(string ruc)
    {
        if (string.IsNullOrEmpty(ruc)) return null;

        var url = $"{_options.SriConsultaRucUrl}?parametro={ruc}";
        var response = await _http.GetAsync(url);
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        var sriResponse = JsonConvert.DeserializeObject<SriApiResponse>(content);
        var data = sriResponse?.consulta?.FirstOrDefault();
        if (data == null) return null;

        return new ClienteValidadoDTO(
            data.numeroRuc,
            data.razonSocial,
            data.representantesLegales?.FirstOrDefault()?.nombre ?? "",
            data.estadoContribuyenteRuc,
            DateTime.TryParse(data.informacionFechasContribuyente?.fechaInicioActividades, out var fi) ? DateOnly.FromDateTime(fi) : null,
            DateTime.TryParse(data.informacionFechasContribuyente?.fechaCese, out var fc) ? DateOnly.FromDateTime(fc) : null,
            data.motivoCancelacionSuspension
        );
    }
}
