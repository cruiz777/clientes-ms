using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ParametrosDetalle
{
    public int Id { get; set; }

    public int IdParametro { get; set; }

    public string Valor { get; set; } = null!;

    public string? Contexto { get; set; }

    public int? IdEmpresa { get; set; }

    public string? Ambiente { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public virtual Parametros IdParametroNavigation { get; set; } = null!;
}
