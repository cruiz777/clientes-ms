using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

/// <summary>
/// Contactos adicionales del proveedor. No requieren ser personas registradas en el sistema.
/// </summary>
public partial class ProveedorContactos
{
    public long IdContacto { get; set; }

    public long IdProveedor { get; set; }

    public string NombreContacto { get; set; } = null!;

    public string? Cargo { get; set; }

    public string? Departamento { get; set; }

    public string? Telefono { get; set; }

    public string? TelefonoMovil { get; set; }

    public string? Email { get; set; }

    public string? Extension { get; set; }

    public string? TipoContacto { get; set; }

    public bool EsPrincipal { get; set; }

    public string? Observaciones { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public long? UsuarioCreacion { get; set; }

    public virtual Proveedores IdProveedorNavigation { get; set; } = null!;
}
