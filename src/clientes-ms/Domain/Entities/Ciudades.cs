using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Ciudades
{
    public long IdCiudad { get; set; }

    public long IdCanton { get; set; }

    public string? Referencia { get; set; }

    public string? Nombre { get; set; }

    public string? Area { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual ICollection<Empresas> Empresas { get; set; } = new List<Empresas>();

    public virtual ICollection<Gln> Gln { get; set; } = new List<Gln>();

    public virtual Cantones IdCantonNavigation { get; set; } = null!;

    public virtual ICollection<Personas> Personas { get; set; } = new List<Personas>();
}
