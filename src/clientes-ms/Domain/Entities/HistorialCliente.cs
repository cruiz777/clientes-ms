using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class HistorialCliente
{
    public long IdHistorialCliente { get; set; }

    public long? IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public long? ClientesCodigo { get; set; }

    public string? Tabla { get; set; }

    public string? TipoAccion { get; set; }

    public long? IdEmpresa { get; set; }

    public virtual Clientes? ClientesCodigoNavigation { get; set; }

    public virtual Empresas? IdEmpresaNavigation { get; set; }
}
