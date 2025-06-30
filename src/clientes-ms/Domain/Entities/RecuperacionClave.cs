using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RecuperacionClave
{
    public int IdRecuperacion { get; set; }

    public long IdUsuario { get; set; }

    public string Token { get; set; } = null!;

    public DateTime FechaExpiracion { get; set; }

    public bool Status { get; set; }

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
