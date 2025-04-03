using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoEmpresaLocalizacion
{
    public long IdTipoEmpresaLocalizacion { get; set; }

    public long? ClientesCodigo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? CodigoPostal { get; set; }

    public virtual Clientes? ClientesCodigoNavigation { get; set; }
}
