using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpEmpleadosDiscapacidad
{
    public long IdEmpleado { get; set; }

    public long? IdTipoDiscapacidad { get; set; }

    public string? CedulaDis { get; set; }

    public string? NombreDis { get; set; }

    public string? RecidenciaEmp { get; set; }

    public long? IdPais { get; set; }

    public string? ConvenioEmp { get; set; }

    public string? SisSalNetEmp { get; set; }

    public string? CodCondDiscap { get; set; }

    public string? CodTipoDiscap { get; set; }

    public string? PorcentajeDiscap { get; set; }

    public string? CarnetConadis { get; set; }

    public string? DescripcionDiscap { get; set; }

    public decimal? IngresosGravOtroEmp { get; set; }

    public decimal? AporteIessOtroEmp { get; set; }

    public decimal? ImpuestoRetOtroEmp { get; set; }

    public decimal? CompEconSalarioDigno { get; set; }

    public long IdEmpresa { get; set; }

    public virtual RpMaeEmp IdEmpleadoNavigation { get; set; } = null!;

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual Paises? IdPaisNavigation { get; set; }

    public virtual RpTipoDiscapacidad? IdTipoDiscapacidadNavigation { get; set; }
}
