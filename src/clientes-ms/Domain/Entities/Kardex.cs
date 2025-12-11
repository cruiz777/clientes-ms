using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Kardex
{
    public long IdProducto { get; set; }

    public DateTime Fecha { get; set; }

    public string Numdoc { get; set; } = null!;

    public string Tipdoc { get; set; } = null!;

    public int IdLocal { get; set; }

    public string? Ingreso { get; set; }

    public string? Egreso { get; set; }

    public string? Saldo { get; set; }

    public string? Descripcion { get; set; }

    public long? IdUsuario { get; set; }

    public double? Costo { get; set; }

    public double? CostoTotal { get; set; }

    public double? Costo2 { get; set; }

    public string? FechaAux { get; set; }

    public double? IdProveedor { get; set; }

    public double? Venta { get; set; }

    public long? IdGrupo { get; set; }

    public long? IdSeccion { get; set; }

    public long? IdDepartamento { get; set; }

    public long? IdSubdivision { get; set; }

    public long? IdDivision { get; set; }

    public double? AuxFecha { get; set; }

    public double? CostoTotal2 { get; set; }

    public string? Signo { get; set; }

    public long? HistoriaClinica { get; set; }

    public long? AtencionCodigo { get; set; }

    public string? Factura { get; set; }

    public long IdKardex { get; set; }

    public double? AsientoContable { get; set; }

    public string? TipoAsiento { get; set; }

    public string IpMaquina { get; set; } = null!;

    public virtual Locales IdLocalNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual TipoMovimiento TipdocNavigation { get; set; } = null!;
}
