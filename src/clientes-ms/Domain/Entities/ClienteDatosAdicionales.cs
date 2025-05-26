using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ClienteDatosAdicionales
{
    public long IdDatosAdicionales { get; set; }

    public bool? Expprod { get; set; }

    public bool? Vendeus { get; set; }

    public bool? Medico { get; set; }

    public bool? Gs1ec { get; set; }

    public bool? Instagram { get; set; }

    public bool? Facebook { get; set; }

    public bool? Web { get; set; }

    public long? ClientesCodigo { get; set; }

    public bool? Prefijo { get; set; }

    public bool? Guia { get; set; }

    public bool? Estado { get; set; }

    public virtual Clientes? ClientesCodigoNavigation { get; set; }
}
