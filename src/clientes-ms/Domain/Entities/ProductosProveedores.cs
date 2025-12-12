using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductosProveedores
{
    public long IdProductoProveedor { get; set; }

    public long IdProducto { get; set; }

    public long IdProveedor { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public string CodigoProveedor { get; set; } = null!;

    public DateTime? FechaIngreso { get; set; }

    public double? CostoCompra { get; set; }

    public double? DescuentoGeneral { get; set; }

    public double? Descuento1 { get; set; }

    public double? Descuento2 { get; set; }

    public double? Descuento3 { get; set; }

    public double? Descuento4 { get; set; }

    public double? CostoNeto { get; set; }

    public double? PorcentajePvp { get; set; }

    public bool? ProductoConsignacion { get; set; }

    public string? UnidadCompra { get; set; }

    public double? ValorUnidadCompra { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool Activo { get; set; }

    public bool EsProveedorPrincipal { get; set; }

    public DateTime? FechaUltimaCompra { get; set; }

    public long? UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacionAudit { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Proveedores IdProveedorNavigation { get; set; } = null!;
}
