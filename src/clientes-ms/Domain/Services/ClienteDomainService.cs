using clientes_ms.Application.DTOs.Clientes;
using clientes_ms.Application.Options;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Interfaces.IDomainServices;
using clientes_ms.Infrastructure.Persistence.Context;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

public class ClienteDomainService : IClienteDomainService
{
    private readonly HttpClient _http;
    private readonly ApisExternasOptions _options;
    private readonly ApplicationDbContext _context;

    public ClienteDomainService(HttpClient http, IOptions<ApisExternasOptions> options, ApplicationDbContext context)
    {
        _http = http;
        _options = options.Value;
        _context = context;
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

    public async Task<List<ClienteSummaryResponse>> GetClientesByNomcliAsync(string filtro)
    {
        if (string.IsNullOrWhiteSpace(filtro))
            throw new ArgumentException("Debe proporcionar un filtro válido (nombre, RUC o código).", nameof(filtro));

        //Intentar parsear el filtro como número para buscar por código
        bool esNumero = long.TryParse(filtro, out long codigoCliente);

        var clientes = await _context.Clientes
            .Where(c =>
                (esNumero && c.ClientesCodigo == codigoCliente) ||
                (!string.IsNullOrEmpty(c.Nomcli) && c.Nomcli.ToLower().Contains(filtro.ToLower())) ||
                (!string.IsNullOrEmpty(c.Ruc) && c.Ruc.Contains(filtro)))
            .OrderBy(c => c.Nomcli)
            .ToListAsync();

        var resultado = clientes.Select(cliente => new ClienteSummaryResponse
        {
            ClientesCodigo = cliente.ClientesCodigo,
            Nomcli = cliente.Nomcli ?? string.Empty,
            Ruc = cliente.Ruc ?? string.Empty
        }).ToList();

        return resultado;
    }


}
