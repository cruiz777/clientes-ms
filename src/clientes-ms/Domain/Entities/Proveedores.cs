using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

/// <summary>
/// Tabla de proveedores vinculada a personas. Contiene solo información específica del proveedor.
/// </summary>
public partial class Proveedores
{
    public long IdProveedor { get; set; }

    public int? IdTipoProveedor { get; set; }

    public int? IdTipoContribuyente { get; set; }

    public long? IdCiudad { get; set; }

    public long? IdPlanCuenta { get; set; }

    public long IdPersona { get; set; }

    public string? NombreProv { get; set; }

    public string? RucProv { get; set; }

    public string? EmailProv { get; set; }

    public string? CodigoPostal { get; set; }

    public string? DireccionProv { get; set; }

    public string? TelefonoProv { get; set; }

    public string? Tel1Prov { get; set; }

    public string? Tel2Prov { get; set; }

    public string CodigoProveedor { get; set; } = null!;

    public string? NombreComercial { get; set; }

    public string WebProveedor { get; set; } = null!;

    public double? PorcentajeRetencionFb { get; set; }

    public string? CodigoRetencionFb { get; set; }

    public double? PorcentajeRetencionFs { get; set; }

    public string? CodigoRetencionFs { get; set; }

    public double? PorcentajeRetencionIb { get; set; }

    public string? CodigoRetencionIb { get; set; }

    public double? PorcentajeRetencionIs { get; set; }

    public string? CodigoRetencionIs { get; set; }

    public double? TiempoEntrega { get; set; }

    public double? PlazoPago { get; set; }

    public bool NoCambiarCostoProducto { get; set; }

    public string? CodigoCuenta { get; set; }

    public string? Observaciones { get; set; }

    public bool Activo { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacionAudit { get; set; }

    public DateTime? FechaModificacionAudit { get; set; }

    public virtual TipoRetencion? CodigoRetencionFbNavigation { get; set; }

    public virtual TipoRetencion? CodigoRetencionFsNavigation { get; set; }

    public virtual TipoRetencion? CodigoRetencionIbNavigation { get; set; }

    public virtual TipoRetencion? CodigoRetencionIsNavigation { get; set; }

    public virtual Ciudades? IdCiudadNavigation { get; set; }

    public virtual Personas IdPersonaNavigation { get; set; } = null!;

    public virtual PlanCuentas? IdPlanCuentaNavigation { get; set; }

    public virtual TipoContribuyente1? IdTipoContribuyenteNavigation { get; set; }

    public virtual TipoProveedor? IdTipoProveedorNavigation { get; set; }

    public virtual ICollection<ProductosProveedores> ProductosProveedores { get; set; } = new List<ProductosProveedores>();

    public virtual ICollection<ProveedorContactos> ProveedorContactos { get; set; } = new List<ProveedorContactos>();
}
