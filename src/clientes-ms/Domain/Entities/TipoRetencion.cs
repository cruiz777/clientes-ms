using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoRetencion
{
    public string CodigoTipoRet { get; set; } = null!;

    public string? Descripcion { get; set; }

    public double? Porcentaje { get; set; }

    public long IdTipoRetencion { get; set; }

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();

    public virtual ICollection<Proveedores> ProveedoresCodigoRetencionFbNavigation { get; set; } = new List<Proveedores>();

    public virtual ICollection<Proveedores> ProveedoresCodigoRetencionFsNavigation { get; set; } = new List<Proveedores>();

    public virtual ICollection<Proveedores> ProveedoresCodigoRetencionIbNavigation { get; set; } = new List<Proveedores>();

    public virtual ICollection<Proveedores> ProveedoresCodigoRetencionIsNavigation { get; set; } = new List<Proveedores>();

    public virtual ICollection<Retenciones> Retenciones { get; set; } = new List<Retenciones>();
}
