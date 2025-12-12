using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CategoriaVideos
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Orden { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public virtual ICollection<VideosAyuda> VideosAyuda { get; set; } = new List<VideosAyuda>();
}
