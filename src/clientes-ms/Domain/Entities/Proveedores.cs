using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Proveedores
{
    public long IdProveedor { get; set; }

    public string CodigoProveedor { get; set; } = null!;

    public string? NombreProveedor { get; set; }

    public string? RucProveedor { get; set; }

    public string? NombreComercial { get; set; }

    public string? CodigoCiudad { get; set; }

    public double? CodigoPais { get; set; }

    public string? DireccionProveedor { get; set; }

    public string? CasillaProveedor { get; set; }

    public string? EmailProveedor { get; set; }

    public string? TelefonoProveedor { get; set; }

    public string? Telefono1Proveedor { get; set; }

    public string? Telefono2Proveedor { get; set; }

    public string? FaxProveedor { get; set; }

    public string? WebProveedor { get; set; }

    public string? ContactoProveedor { get; set; }

    public string? RepresentanteProveedor { get; set; }

    public string? TipoProveedor { get; set; }

    public string? TipoProducto { get; set; }

    public string? CodigoEan { get; set; }

    public string? OrigenProveedor { get; set; }

    public bool TipoNacionalInternacional { get; set; }

    public bool TipoContado { get; set; }

    public int TipoProduccion { get; set; }

    public double? PorcentajeRetencion { get; set; }

    public string? MotivoRetencion { get; set; }

    public bool Tarifa { get; set; }

    public double? PorcentajeRetencionFb { get; set; }

    public string? CodigoRetencionFb { get; set; }

    public double? PorcentajeRetencionFs { get; set; }

    public string? CodigoRetencionFs { get; set; }

    public double? PorcentajeRetencionIb { get; set; }

    public string? CodigoRetencionIb { get; set; }

    public double? PorcentajeRetencionIs { get; set; }

    public string? CodigoRetencionIs { get; set; }

    public string? Autorizacion { get; set; }

    public DateTime? FechaCaducidad { get; set; }

    public double? TiempoEntrega { get; set; }

    public string? FormaPago { get; set; }

    public double? PlazoPago { get; set; }

    public double? PlazoPagoC { get; set; }

    public string? DescuentoGlobalMonto { get; set; }

    public double? PorcentajePvp { get; set; }

    public double? PorcentajeDescuento { get; set; }

    public double? MontoDescuento { get; set; }

    public bool NoCambiarCostoProducto { get; set; }

    public string? CodigoBanco { get; set; }

    public string? CuentaCorriente { get; set; }

    public string? CodigoCuenta { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool Activo { get; set; }

    public long? UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public long? UsuarioModificacionAudit { get; set; }

    public DateTime? FechaModificacionAudit { get; set; }

    public long? IdPersona { get; set; }

    public virtual Personas? IdPersonaNavigation { get; set; }

    public virtual ICollection<ProductosProveedores> ProductosProveedores { get; set; } = new List<ProductosProveedores>();
}
