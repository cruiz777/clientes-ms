using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class SecuenciasDocumento
{
    public int Id { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public long UltimoNumero { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public string? UsuarioActualizacion { get; set; }
}
