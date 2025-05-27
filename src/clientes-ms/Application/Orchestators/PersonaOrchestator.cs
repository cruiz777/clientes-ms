using AutoMapper;
using clientes_ms.Application.Records.Request;
using clientes_ms.Domain.Entities;
using clientes_ms.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace clientes_ms.Application.Orchestators;

public class PersonaOrquestadorService
{
    private readonly ApplicationDbContext _context;
    private readonly HttpClient _http;
    private readonly IMapper _mapper;

    public PersonaOrquestadorService(ApplicationDbContext context, HttpClient http, IMapper mapper)
    {
        _context = context;
        _http = http;
        _mapper = mapper;
    }

    public async Task<long> CrearPersonaDesdeClienteAsync(ClientesRequest cliente)
    {
        var numeroDoc = cliente.Ruc?.Trim();

        if (string.IsNullOrWhiteSpace(numeroDoc))
            throw new ArgumentException("Número de documento no puede estar vacío.");

        long tipoDoc = numeroDoc.Length switch
        {
            10 => 1, // Cédula
            13 => 3, // RUC
            _ => 2   // Pasaporte
        };

        // Verificar si ya existe
        var existente = await _context.Personas.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Documento == numeroDoc);

        if (existente != null)
            return existente.IdPersona;

        // Base de persona
        var personaReq = new PersonaRequest
        {
            NumeroDocumento = numeroDoc,
            IdTipoDocumento = tipoDoc,
            IdCiudad = cliente.IdCiudad,
            FechaNacimiento = cliente.Fecnac ?? DateOnly.FromDateTime(DateTime.Now),
            TipoPersona = "JURÍDICA",
            Status = true,
            Correos = new List<CorreoRequest>
            {
                new() { Email = cliente.Email?.Trim() ?? "", Tipo = "Trabajo" }
            },
            Telefonos = new List<TelefonoRequest>
            {
                new() { Numero = cliente.Telefono1 ?? "", Tipo = "Móvil" },
                new() { Numero = cliente.Telefono ?? "", Tipo = "Otro" }
            },
            Direcciones = new List<DireccionRequest>
            {
                new() {
                    Tipo = "Trabajo",
                    Calle = cliente.Dircli ?? "",
                    Ciudad = cliente.Ciudad,
                    CodigoPostal = cliente.CodigoPostal
                }
            }
        };

        if (tipoDoc == 1)
        {
            var rc = await _http.GetFromJsonAsync<RegistroCivilResponse>(
                $"http://localhost:5001/api/apis-externas/cedula/consultar?parametro={numeroDoc}");

            if (rc is not null)
            {
                var nombres = rc.Nombre?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? [];

                personaReq.Apellido1 = nombres.ElementAtOrDefault(0);
                personaReq.Apellido2 = nombres.ElementAtOrDefault(1);
                personaReq.Nombre1 = nombres.ElementAtOrDefault(2);
                personaReq.Nombre2 = nombres.ElementAtOrDefault(3);

                personaReq.IdGenero = MapGenero(rc.Genero);
                personaReq.IdEstadoCivil = MapEstadoCivil(rc.EstadoCivil);

                if (DateTime.TryParse(rc.FechaNacimiento, out var nac))
                    personaReq.FechaNacimiento = DateOnly.FromDateTime(nac);

                personaReq.TipoPersona = "NATURAL";
            }
        }
        else if (tipoDoc == 3)
        {
            var wrapper = await _http.GetFromJsonAsync<SriWrapperResponse>(
                $"http://localhost:5001/api/apis-externas/ruc/consultar?parametro={numeroDoc}");

            var sri = wrapper?.Consulta?.FirstOrDefault();

            personaReq.Nombre1 ??= cliente.RazonSocial ?? sri?.RazonSocial;
            personaReq.Apellido1 ??= cliente.Representante;
            personaReq.IdGenero = 3;
            personaReq.IdEstadoCivil = 5; // NO APLICA

            if (DateTime.TryParse(sri?.InformacionFechasContribuyente?.FechaInicioActividades, out var fechaInicio))
                personaReq.FechaNacimiento = DateOnly.FromDateTime(fechaInicio);
        }


        var persona = _mapper.Map<Personas>(personaReq);
        persona.FechaRegistro = DateTime.Now;

        if (personaReq.Correos?.Any() == true)
            persona.Correos = _mapper.Map<List<Correos>>(personaReq.Correos);

        if (personaReq.Telefonos?.Any() == true)
            persona.Telefonos = _mapper.Map<List<Telefonos>>(personaReq.Telefonos);

        if (personaReq.Direcciones?.Any() == true)
            persona.Direcciones = _mapper.Map<List<Direcciones>>(personaReq.Direcciones);

        await _context.Personas.AddAsync(persona);
        await _context.SaveChangesAsync();

        return persona.IdPersona;
    }

    // Conversión texto → código
    private static long MapEstadoCivil(string? estado) =>
        estado?.ToUpper().Trim() switch
        {
            "CASADO" => 1,
            "DIVORCIADO" => 2,
            "UNION LIBRE" => 3,
            "SOLTERO" => 4,
            "NO APLICA" or null => 5,
            _ => 5
        };

    private static long MapGenero(string? genero) =>
        genero?.ToUpper().Trim() switch
        {
            "HOMBRE" => 1,
            "MUJER" => 2,
            _ => 3
        };

    // Modelos externos
    public record RegistroCivilResponse(
        string Cedula,
        string Nombre,
        string Genero,
        string FechaNacimiento,
        string EstadoCivil,
        string? Conyuge,
        string? Nacionalidad,
        string? FechaCedulacion,
        string? LugarDomicilio,
        string? CalleDomicilio,
        string? NumeracionDomicilio,
        string? NombreMadre,
        string? NombrePadre,
        string? LugarNacimiento,
        string? Instruccion,
        string? Profesion
    );

    public class SriWrapperResponse
    {
        public bool Ok { get; set; }
        public List<SriConsulta> Consulta { get; set; } = [];
    }

    public class SriConsulta
    {
        public string RazonSocial { get; set; } = string.Empty;
        public string? EstadoContribuyenteRuc { get; set; }
        public string? TipoContribuyente { get; set; }
        public InformacionFechasContribuyente InformacionFechasContribuyente { get; set; } = new();
        public List<RepresentanteLegal>? RepresentantesLegales { get; set; }
    }

    public class InformacionFechasContribuyente
    {
        public string? FechaInicioActividades { get; set; }
    }

    public class RepresentanteLegal
    {
        public string? NombreRepresentante { get; set; }
    }

}
