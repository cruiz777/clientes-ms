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

    public int IntentosFallidos { get; set; }

    public bool EstaBloqueado { get; set; }

    public DateTime? FechaBloqueo { get; set; }

    public DateTime? FechaCaducidad { get; set; }

    public virtual ICollection<ActivoFijo> ActivoFijo { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<AuditoriaTransferencia> AuditoriaTransferencia { get; set; } = new List<AuditoriaTransferencia>();

    public virtual ICollection<AutorizacionCajaUsuario> AutorizacionCajaUsuario { get; set; } = new List<AutorizacionCajaUsuario>();

    public virtual ICollection<CabeceraConciliacion> CabeceraConciliacion { get; set; } = new List<CabeceraConciliacion>();

    public virtual ICollection<CabeceraLiquidacion> CabeceraLiquidacion { get; set; } = new List<CabeceraLiquidacion>();

    public virtual ICollection<CabeceraMaestro> CabeceraMaestro { get; set; } = new List<CabeceraMaestro>();

    public virtual ICollection<ClienteObservacion> ClienteObservacion { get; set; } = new List<ClienteObservacion>();

    public virtual ICollection<Codigos14> Codigos14 { get; set; } = new List<Codigos14>();

    public virtual ICollection<CodigosContables> CodigosContables { get; set; } = new List<CodigosContables>();

    public virtual ICollection<CuentasPorPagar> CuentasPorPagar { get; set; } = new List<CuentasPorPagar>();

    public virtual ICollection<Cupones> Cupones { get; set; } = new List<Cupones>();

    public virtual ICollection<Gln> Gln { get; set; } = new List<Gln>();

    public virtual ICollection<HistorialContrasenias> HistorialContrasenias { get; set; } = new List<HistorialContrasenias>();

    public virtual Departamentos IdDepartamentoNavigation { get; set; } = null!;

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual Personas IdPersonaNavigation { get; set; } = null!;

    public virtual ICollection<NominaEspecial> NominaEspecial { get; set; } = new List<NominaEspecial>();

    public virtual ICollection<NominaProvisiones> NominaProvisiones { get; set; } = new List<NominaProvisiones>();

    public virtual ICollection<PlanificacionPagos> PlanificacionPagosUsuarioApruebaNavigation { get; set; } = new List<PlanificacionPagos>();

    public virtual ICollection<PlanificacionPagos> PlanificacionPagosUsuarioIngNavigation { get; set; } = new List<PlanificacionPagos>();

    public virtual ICollection<ProductoDatosAdicionales> ProductoDatosAdicionales { get; set; } = new List<ProductoDatosAdicionales>();

    public virtual ICollection<RecuperacionClave> RecuperacionClave { get; set; } = new List<RecuperacionClave>();

    public virtual ICollection<Retenciones> Retenciones { get; set; } = new List<Retenciones>();

    public virtual ICollection<RolNomina> RolNomina { get; set; } = new List<RolNomina>();

    public virtual ICollection<RolNominaQuincena> RolNominaQuincena { get; set; } = new List<RolNominaQuincena>();

    public virtual ICollection<RubrosFijos> RubrosFijos { get; set; } = new List<RubrosFijos>();

    public virtual ICollection<UsuariosPerfiles> UsuariosPerfiles { get; set; } = new List<UsuariosPerfiles>();

    public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; } = new List<UsuariosRoles>();
}
