using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class IngresoDescuentos
{
    public int IdIngDesc { get; set; }

    public string? Codigo { get; set; }

    public string? TipoPago { get; set; }

    public string? Descripcion { get; set; }

    public string? CtaContable { get; set; }

    public string? CtaContable2 { get; set; }

    public string? CtaContable3 { get; set; }

    public string? CtaContable4 { get; set; }

    public string? CtaContable5 { get; set; }

    public bool? Estado { get; set; }

    public string? PorcenCant { get; set; }

    public string? Observacion { get; set; }

    public bool? Incluir { get; set; }

    public bool? Calculado { get; set; }

    public bool? Aportaciones { get; set; }

    public int? Orden { get; set; }

    public string? DH { get; set; }

    public bool? Desac { get; set; }

    public bool? ParSue { get; set; }

    public bool? EstVacaciones { get; set; }

    public bool? EstFondosReserva { get; set; }

    public bool? EstDecimoTercer { get; set; }

    public bool? EstImpuestoRenta { get; set; }

    public bool? EstOtrosIng { get; set; }

    public bool? AplicaAportesPatPer { get; set; }

    public bool? EstRubrosLiquida { get; set; }

    public bool? EstOtrosIngImp { get; set; }

    public bool? EstIngImp { get; set; }

    public bool? EstIngImpFr { get; set; }

    public bool? SumaDias { get; set; }

    public virtual ICollection<NominaProvisiones> NominaProvisiones { get; set; } = new List<NominaProvisiones>();

    public virtual ICollection<RolNomina> RolNomina { get; set; } = new List<RolNomina>();

    public virtual ICollection<RolNominaQuincena> RolNominaQuincena { get; set; } = new List<RolNominaQuincena>();

    public virtual ICollection<RubrosFijos> RubrosFijos { get; set; } = new List<RubrosFijos>();
}
