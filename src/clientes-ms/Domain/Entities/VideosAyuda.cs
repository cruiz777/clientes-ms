using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class VideosAyuda
{
    public long Id { get; set; }

    public long IdSistema { get; set; }

    public long IdCategoria { get; set; }

    public string Titulo { get; set; } = null!;

    public string UrlVideo { get; set; } = null!;

    public int Orden { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public virtual CategoriaVideos IdCategoriaNavigation { get; set; } = null!;

    public virtual Sistemas IdSistemaNavigation { get; set; } = null!;
}
