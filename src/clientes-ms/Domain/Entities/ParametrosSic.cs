using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ParametrosSic
{
    public long IdParametro { get; set; }

    public long IdEmpresa { get; set; }

    public string? Codcueiva { get; set; }

    public string? Codcuedesc { get; set; }

    public string? Codcueimprenta { get; set; }

    public string? Codcueretiva { get; set; }

    public double? Ivaservicio { get; set; }

    public double? Ivamercaderia { get; set; }

    public double? Imprenta { get; set; }

    public double? Iva { get; set; }

    public string? CodigoIvaSri { get; set; }

    public bool FacturaPreimpresa { get; set; }

    public bool Habilitacupo { get; set; }

    public bool Ctadivision { get; set; }

    public bool Ctasubdivision { get; set; }

    public bool Ctadepartamento { get; set; }

    public bool Ctagrupo { get; set; }

    public bool Ctaseccion { get; set; }

    public bool Ctaproducto { get; set; }

    public string? Codcuectaxpag { get; set; }

    public double? StockMax { get; set; }

    public double? StockMin { get; set; }

    public double? Regalia { get; set; }

    public string? TipoRegalia { get; set; }

    public bool Inventariar { get; set; }

    public bool Caducidad { get; set; }

    public double? Pais { get; set; }

    public double? Zona { get; set; }

    public double? Ivacompra { get; set; }

    public string? Codcueinventarios { get; set; }

    public string? Codcueivacompra { get; set; }

    public bool Cambiarcodpro { get; set; }

    public bool Costogeneral { get; set; }

    public bool VariosLocales { get; set; }

    public bool Opcion1 { get; set; }

    public double? Numfondoinicial { get; set; }

    public bool RecibirConOrden { get; set; }

    public bool Codpre { get; set; }

    public bool Activabod { get; set; }

    public bool Activausu { get; set; }

    public bool Prodcomp { get; set; }

    public bool Icxcconta { get; set; }

    public short? PosDec { get; set; }

    public string? Iprincipal { get; set; }

    public string? Isecundaria1 { get; set; }

    public string? Isecundaria2 { get; set; }

    public string? Codcueanticipo { get; set; }

    public string? Codcuediff { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;
}
