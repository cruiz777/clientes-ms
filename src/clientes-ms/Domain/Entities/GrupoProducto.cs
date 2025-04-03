using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class GrupoProducto
{
    public long IdGrupoProducto { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public string? Segmento { get; set; }

    public string? DesSegmento { get; set; }

    public string? Familia { get; set; }

    public string? DesFamilia { get; set; }

    public string? Clase { get; set; }

    public string? DesClase { get; set; }

    public string? Brick { get; set; }

    public string? DesBrick { get; set; }

    public string? DesSegmentoing { get; set; }

    public string? DesFamiliaing { get; set; }

    public string? DesClaseing { get; set; }

    public string? DesBricking { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();
}
