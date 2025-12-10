using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DatosCuentasProveedores
{
    public double CodigoC { get; set; }

    public long IdDatosCueProv { get; set; }

    public string? Tipocuenta { get; set; }

    public double? Tipcuenta { get; set; }

    public double? Cuentabanc { get; set; }

    public string? Tipoidentificacion { get; set; }

    public string? Nidentificacion { get; set; }

    public long? IdEmpresa { get; set; }
}
