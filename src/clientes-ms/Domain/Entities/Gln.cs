using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Gln
{
    public long IdGln { get; set; }

    public long IdPrefijos { get; set; }

    public long ClientesCodigo { get; set; }

    public string? Gln1 { get; set; }

    public long? IdTipoLocalizacion { get; set; }

    public string? GlnLatitud { get; set; }

    public string? GlnLongitud { get; set; }

    public long? IdPais { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Fax { get; set; }

    public string? Contacto { get; set; }

    public string? ContactoTel { get; set; }

    public string? Email { get; set; }

    public string? Web { get; set; }

    public string? Fda { get; set; }

    public string? Europa { get; set; }

    public string? GlnGlobal { get; set; }

    public DateOnly? GlnFecha { get; set; }

    public long? IdCiudad { get; set; }

    public string? GlnCodigopostal { get; set; }

    public string? GlnCelular { get; set; }

    public string? GlnContacto2 { get; set; }

    public string? GlnEmail2 { get; set; }

    public string? GlnTel2 { get; set; }

    public string? GlnContacto3 { get; set; }

    public string? GlnEmail3 { get; set; }

    public string? GlnTel3 { get; set; }

    public string? GlnFacturar { get; set; }

    public string? GlnCodpro { get; set; }

    public string? GlnNombre { get; set; }

    public string? GlnOtro1 { get; set; }

    public string? GlnOtro2 { get; set; }

    public string? GlnObs1 { get; set; }

    public string? GlnObs2 { get; set; }

    public string? GlnOrigenprefijo { get; set; }

    public string? GlnPrefijogs1 { get; set; }

    public string? GlnGlnp { get; set; }

    public string? GlnGlne { get; set; }

    public string? NombreLocalizacion { get; set; }

    public string? Observ { get; set; }

    public int Expprod { get; set; }

    public int Gs1ec { get; set; }

    public int Gs1latam { get; set; }

    public int Gas1org { get; set; }

    public int Google { get; set; }

    public string? Gs1otros { get; set; }

    public string? LongG { get; set; }

    public string? LongM { get; set; }

    public string? LongS { get; set; }

    public string? LongE { get; set; }

    public string? LatiG { get; set; }

    public string? LatiM { get; set; }

    public string? LatiS { get; set; }

    public string? LatiE { get; set; }

    public long? IdUsuario { get; set; }

    public virtual Clientes ClientesCodigoNavigation { get; set; } = null!;

    public virtual Ciudades? IdCiudadNavigation { get; set; }

    public virtual Paises? IdPaisNavigation { get; set; }

    public virtual Prefijos IdPrefijosNavigation { get; set; } = null!;

    public virtual TipoLocalizacion? IdTipoLocalizacionNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
