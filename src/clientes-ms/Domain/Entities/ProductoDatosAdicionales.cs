using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoDatosAdicionales
{
    public long IdProductoDatosAdicionales { get; set; }

    public long ClientesCodigo { get; set; }

    public long? IdPrefijos { get; set; }

    public long? IdTipoCodigoGs1 { get; set; }

    public long? IdGrupoProducto { get; set; }

    public double? Peso1 { get; set; }

    public long? IdUsuario { get; set; }

    public string? Facturar { get; set; }

    public string? Nombre { get; set; }

    public string? Gtin { get; set; }

    public string? Target { get; set; }

    public string? Marca { get; set; }

    public string? Autfuncion { get; set; }

    public string? Registros { get; set; }

    public string? Obsc { get; set; }

    public long? IdSector { get; set; }

    public string? Contenido { get; set; }

    public string? Um { get; set; }

    public string? Brick { get; set; }

    public string? Pais { get; set; }

    public string? Url { get; set; }

    public string? Pum { get; set; }

    public string? Lum { get; set; }

    public string? Aum { get; set; }

    public string? Url2 { get; set; }

    public string? Pais2 { get; set; }

    public string? Pais3 { get; set; }

    public string? Codint { get; set; }

    public string? Secto2 { get; set; }

    public string? Sector3 { get; set; }

    public int? SolFavorita { get; set; }

    public int? SolRosado { get; set; }

    public int? SolSantamaria { get; set; }

    public int? SolTia { get; set; }

    public int? SolAmazon { get; set; }

    public int? SolGoogle { get; set; }

    public int? SolEbay { get; set; }

    public string? SolOtros { get; set; }

    public long? IdProducto { get; set; }

    public virtual Clientes ClientesCodigoNavigation { get; set; } = null!;

    public virtual GrupoProducto? IdGrupoProductoNavigation { get; set; }

    public virtual Prefijos? IdPrefijosNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Sector? IdSectorNavigation { get; set; }

    public virtual TipoCodigoGs1? IdTipoCodigoGs1Navigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
