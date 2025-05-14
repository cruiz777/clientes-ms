using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class HistorialCliente
{
    public long IdHistorialCliente { get; set; }

    public long? IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public long? ClientesCodigo { get; set; }

    public virtual Clientes? ClientesCodigoNavigation { get; set; }
}
