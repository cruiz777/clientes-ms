using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Usuarios
{
    public long IdUsuario { get; set; }

    public long IdPersona { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ContraseniaHash { get; set; } = null!;

    public bool Estado { get; set; }

    public string? Correo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public long IdEmpresa { get; set; }

    public long IdDepartamento { get; set; }

    public virtual ICollection<AuditoriaTransferencia> AuditoriaTransferencia { get; set; } = new List<AuditoriaTransferencia>();

    public virtual ICollection<ClienteObservacion> ClienteObservacion { get; set; } = new List<ClienteObservacion>();

    public virtual ICollection<Codigos14> Codigos14 { get; set; } = new List<Codigos14>();

    public virtual ICollection<Gln> Gln { get; set; } = new List<Gln>();

    public virtual Departamentos IdDepartamentoNavigation { get; set; } = null!;

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual Personas IdPersonaNavigation { get; set; } = null!;

    public virtual ICollection<ProductoDatosAdicionales> ProductoDatosAdicionales { get; set; } = new List<ProductoDatosAdicionales>();

    public virtual ICollection<UsuariosPerfiles> UsuariosPerfiles { get; set; } = new List<UsuariosPerfiles>();

    public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; } = new List<UsuariosRoles>();
}
