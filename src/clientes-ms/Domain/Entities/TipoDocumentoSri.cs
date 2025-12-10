using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoDocumentoSri
{
    public long IdTipoDocumento { get; set; }

    public string? Descripcion { get; set; }

    public string? DocumentoSri { get; set; }

    public virtual ICollection<AutorizacionCaja> AutorizacionCaja { get; set; } = new List<AutorizacionCaja>();
}
