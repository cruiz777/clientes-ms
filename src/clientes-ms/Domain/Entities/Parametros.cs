using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Parametros
{
    public int Id { get; set; }

    public string Clave { get; set; } = null!;

    public string Valor { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }
}
