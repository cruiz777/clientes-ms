namespace clientes_ms.Application.Records.Request;

public class PersonaRequest
{
    public string NumeroDocumento { get; set; } = string.Empty;

    public long IdTipoDocumento { get; set; }

    public string? Nombre1 { get; set; }
    public string? Nombre2 { get; set; }
    public string? Apellido1 { get; set; }
    public string? Apellido2 { get; set; }

    public long IdGenero { get; set; }
    public long IdEstadoCivil { get; set; }

    public DateOnly? FechaNacimiento { get; set; }
    public string? TipoPersona { get; set; }

    public long IdCiudad { get; set; }

    public bool Status { get; set; } = true;

    public List<CorreoRequest> Correos { get; set; } = new();
    public List<TelefonoRequest> Telefonos { get; set; } = new();
    public List<DireccionRequest> Direcciones { get; set; } = new();
}

public class CorreoRequest
{
    public string Tipo { get; set; } = "Trabajo";
    public string Email { get; set; } = string.Empty;
}

public class TelefonoRequest
{
    public string Tipo { get; set; } = "Móvil";
    public string Numero { get; set; } = string.Empty;
}

public class DireccionRequest
{
    public string Tipo { get; set; } = "Casa";
    public string Calle { get; set; } = string.Empty;
    public string? Ciudad { get; set; }
    public string? Estado { get; set; }
    public string? CodigoPostal { get; set; }
    public string? Pais { get; set; }
}
