using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Cupones
{
    public long IdCupon { get; set; }

    public string CodigoCupon { get; set; } = null!;

    public long IdCliente { get; set; }

    public long IdPrefijo { get; set; }

    public int? Serial { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaCaducidad { get; set; }

    public bool Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public long? IdGrupoProducto { get; set; }

    public string? Descripcion { get; set; }

    public long? IdUsuario { get; set; }

    public virtual Clientes IdClienteNavigation { get; set; } = null!;

    public virtual GrupoProducto? IdGrupoProductoNavigation { get; set; }

    public virtual Prefijos IdPrefijoNavigation { get; set; } = null!;

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
