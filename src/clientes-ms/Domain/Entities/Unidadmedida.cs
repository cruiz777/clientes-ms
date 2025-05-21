using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Unidadmedida
{
    public int Codigo { get; set; }

    public string? Descripcion { get; set; }

    public string? Unidad { get; set; }

    public string? NetContentUom { get; set; }

    public bool Estado { get; set; }
}
