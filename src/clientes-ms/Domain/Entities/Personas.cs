﻿using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Personas
{
    public long IdPersona { get; set; }

    public string Documento { get; set; } = null!;

    public string Nombre1 { get; set; } = null!;

    public string? Nombre2 { get; set; }

    public string Apellido1 { get; set; } = null!;

    public string? Apellido2 { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public long IdEstadoCivil { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? TipoPersona { get; set; }

    public long IdTipoDocumento { get; set; }

    public long IdGenero { get; set; }

    public bool Status { get; set; }

    public long IdCiudad { get; set; }

    public virtual ICollection<Contadores> Contadores { get; set; } = new List<Contadores>();

    public virtual ICollection<Correos> Correos { get; set; } = new List<Correos>();

    public virtual ICollection<Direcciones> Direcciones { get; set; } = new List<Direcciones>();

    public virtual ICollection<Gerentes> Gerentes { get; set; } = new List<Gerentes>();

    public virtual Ciudades IdCiudadNavigation { get; set; } = null!;

    public virtual EstadoCivil IdEstadoCivilNavigation { get; set; } = null!;

    public virtual Genero IdGeneroNavigation { get; set; } = null!;

    public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; } = null!;

    public virtual ICollection<Telefonos> Telefonos { get; set; } = new List<Telefonos>();

    public virtual Usuarios? Usuarios { get; set; }
}
