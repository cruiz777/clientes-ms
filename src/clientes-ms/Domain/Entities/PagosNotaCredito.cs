using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PagosNotaCredito
{
    public long IdPagosNc { get; set; }

    public string? Id { get; set; }

    public long? ClientesCodigo { get; set; }

    public string? Numnota { get; set; }

    public string? Numdoc { get; set; }

    public string? Forpag { get; set; }

    public double? Valor { get; set; }

    public string? CuentaContable { get; set; }

    public string? Estado { get; set; }

    public int? Fila { get; set; }

    public DateTime? Fecha { get; set; }

    public long? IdNotaCredito { get; set; }

    public virtual Clientes? ClientesCodigoNavigation { get; set; }

    public virtual NotaCredito? IdNotaCreditoNavigation { get; set; }
}
