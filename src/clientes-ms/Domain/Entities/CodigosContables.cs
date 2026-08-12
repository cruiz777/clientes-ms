using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CodigosContables
{
    public long IdCodContable { get; set; }

    public string? Identificacionauxiliar { get; set; }

    public string? Nombreauxiliar { get; set; }

    public string? Direccionauxiliar { get; set; }

    public string? Telefonoauxiliar { get; set; }

    public string? Celularauxiliar { get; set; }

    public string? Emailauxiliar { get; set; }

    public double? Plazo { get; set; }

    public string? Razonsocial { get; set; }

    public string? ActividadComercial { get; set; }

    public string? Tipopersona { get; set; }

    public int? Parterelacionada { get; set; }

    public long IdPersona { get; set; }

    public long IdEmpresa { get; set; }

    public long IdCiudad { get; set; }

    public long IdTipoContribuyente { get; set; }

    public long IdUsuario { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaRegistro { get; set; }

    public string? Nombre1 { get; set; }

    public string? Nombre2 { get; set; }

    public string? Apellido1 { get; set; }

    public string? Apellido2 { get; set; }

    public int? Tipoidentificacion { get; set; }

    public bool? EstadoRuc { get; set; }

    public DateOnly? FechaInicioAct { get; set; }

    public virtual ICollection<CabeceraLiquidacion> CabeceraLiquidacion { get; set; } = new List<CabeceraLiquidacion>();

    public virtual ICollection<CuentasPorPagar> CuentasPorPagar { get; set; } = new List<CuentasPorPagar>();

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();

    public virtual Ciudades IdCiudadNavigation { get; set; } = null!;

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual Personas IdPersonaNavigation { get; set; } = null!;

    public virtual TipoContribuyente IdTipoContribuyenteNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<PlanificacionPagos> PlanificacionPagos { get; set; } = new List<PlanificacionPagos>();

    public virtual ICollection<Retenciones> Retenciones { get; set; } = new List<Retenciones>();
}
