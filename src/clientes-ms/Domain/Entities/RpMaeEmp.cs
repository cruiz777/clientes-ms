using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpMaeEmp
{
    public long IdEmpleado { get; set; }

    public long IdEmpresa { get; set; }

    public long IdCargo { get; set; }

    public long IdTipemp { get; set; }

    public long IdPersona { get; set; }

    public long IdNacionalidad { get; set; }

    public bool? Carcony { get; set; }

    public int? Carhijos { get; set; }

    public int? Numafil { get; set; }

    public long? IdSectorial { get; set; }

    public string? Foto { get; set; }

    public long? IdTipoSangre { get; set; }

    public string? Codcentel { get; set; }

    public string? CtaCble { get; set; }

    public bool Provisiones { get; set; }

    public bool Decimos { get; set; }

    public bool Decimo3ro { get; set; }

    public bool Freserva { get; set; }

    public long? IdRegimen { get; set; }

    public bool? Discap { get; set; }

    public bool? Teredad { get; set; }

    public long? IdEmpresaComplementaria { get; set; }

    public bool? Galapagos { get; set; }

    public bool? Enfcatastro { get; set; }

    public bool RetJudicial { get; set; }

    public double? ValorRetencionJ { get; set; }

    public long? IdGrupoOcupacional { get; set; }

    public bool RepLegal { get; set; }

    public bool ImpRenta { get; set; }

    public DateOnly? FechaSueldo { get; set; }

    public decimal? Sueldo { get; set; }

    public decimal? ValorHora { get; set; }

    public decimal? ValorHoraEspe { get; set; }

    public bool? Valhorain { get; set; }

    public decimal? Quincena { get; set; }

    public decimal? QuincenaIi { get; set; }

    public long? IdZona { get; set; }

    public int? IdLocal { get; set; }

    public long? IdDepartamento { get; set; }

    public DateOnly? FecNac { get; set; }

    public long? IdCiudadTrabajo { get; set; }

    public DateOnly? Feinivac { get; set; }

    public DateOnly? Fefinvac { get; set; }

    public string? Establecimiento { get; set; }

    public string? Lmilitar { get; set; }

    public virtual ICollection<Cargas> Cargas { get; set; } = new List<Cargas>();

    public virtual ICollection<GastosSri> GastosSri { get; set; } = new List<GastosSri>();

    public virtual RpCargos IdCargoNavigation { get; set; } = null!;

    public virtual Ciudades? IdCiudadTrabajoNavigation { get; set; }

    public virtual Departamentos? IdDepartamentoNavigation { get; set; }

    public virtual RpEmpresaComplementaria? IdEmpresaComplementariaNavigation { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual RpGrupoOcupacional? IdGrupoOcupacionalNavigation { get; set; }

    public virtual Locales? IdLocalNavigation { get; set; }

    public virtual Nacionalidad IdNacionalidadNavigation { get; set; } = null!;

    public virtual Personas IdPersonaNavigation { get; set; } = null!;

    public virtual RpRegimen? IdRegimenNavigation { get; set; }

    public virtual Sectorial? IdSectorialNavigation { get; set; }

    public virtual RpTipEmp IdTipempNavigation { get; set; } = null!;

    public virtual RpTipoSangre? IdTipoSangreNavigation { get; set; }

    public virtual Zona? IdZonaNavigation { get; set; }

    public virtual ICollection<NominaEspecial> NominaEspecial { get; set; } = new List<NominaEspecial>();

    public virtual ICollection<Observaciones> Observaciones { get; set; } = new List<Observaciones>();

    public virtual ICollection<RolNomina> RolNomina { get; set; } = new List<RolNomina>();

    public virtual ICollection<RolNominaQuincena> RolNominaQuincena { get; set; } = new List<RolNominaQuincena>();

    public virtual RpEmpleadosDiscapacidad? RpEmpleadosDiscapacidad { get; set; }

    public virtual ICollection<RpMaeEmpCronologia> RpMaeEmpCronologia { get; set; } = new List<RpMaeEmpCronologia>();

    public virtual ICollection<RpMaeEmpFormacion> RpMaeEmpFormacion { get; set; } = new List<RpMaeEmpFormacion>();

    public virtual ICollection<RpMaeEmpHistorialBanco> RpMaeEmpHistorialBanco { get; set; } = new List<RpMaeEmpHistorialBanco>();

    public virtual ICollection<RubrosFijos> RubrosFijos { get; set; } = new List<RubrosFijos>();
}
