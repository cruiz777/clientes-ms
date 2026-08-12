using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class AuditoriaDatosAdicionalesCliente
{
    public long IdAuditoria { get; set; }

    public int ClientesCodigo { get; set; }

    public string Campo { get; set; } = null!;

    public bool ValorAnterior { get; set; }

    public bool ValorNuevo { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime Fecha { get; set; }

    public string? NombreCliente { get; set; }
}
