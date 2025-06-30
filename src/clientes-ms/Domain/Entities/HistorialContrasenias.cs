using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class HistorialContrasenias
{
    public long IdHistorial { get; set; }

    public long IdUsuario { get; set; }

    public string ContraseniaHash { get; set; } = null!;

    public DateTime FechaCambio { get; set; }

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
