using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Codigos14
{
    public long IdCodigos14 { get; set; }

    public string? Codbar { get; set; }

    public long? IdPrefijos { get; set; }

    public long? IdCliente { get; set; }

    public int? Presentacion { get; set; }

    public double? Unidad { get; set; }

    public string? Descripcion { get; set; }

    public string? G14 { get; set; }

    public double? Largo { get; set; }

    public double? Ancho { get; set; }

    public double? Profundidad { get; set; }

    public double? Peso { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Foto { get; set; }

    public bool? Activo { get; set; }

    public long? IdUsuario { get; set; }

    public string? Codpro { get; set; }

    public string? Facturar { get; set; }

    public string? Nombre { get; set; }

    public string? Gtin { get; set; }

    public string? Target { get; set; }

    public string? Marca { get; set; }

    public string? Sector { get; set; }

    public string? Referencia { get; set; }

    public string? Abrevia { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
