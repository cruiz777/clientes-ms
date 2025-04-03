using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Perfiles
{
    public long IdPerfil { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public long IdEmpresa { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<PerfilesMenus> PerfilesMenus { get; set; } = new List<PerfilesMenus>();

    public virtual ICollection<PerfilesModulos> PerfilesModulos { get; set; } = new List<PerfilesModulos>();

    public virtual ICollection<PerfilesOpciones> PerfilesOpciones { get; set; } = new List<PerfilesOpciones>();

    public virtual ICollection<PerfilesSistemas> PerfilesSistemas { get; set; } = new List<PerfilesSistemas>();

    public virtual ICollection<UsuariosPerfiles> UsuariosPerfiles { get; set; } = new List<UsuariosPerfiles>();
}
