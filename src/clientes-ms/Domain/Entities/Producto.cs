using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Producto
{
    public long IdProducto { get; set; }

    public string? Codpro { get; set; }

    public string? Despro { get; set; }

    public string? Tippro { get; set; }

    public long? GrupoCodigo { get; set; }

    public long? IdSeccion { get; set; }

    public long? IdDepartamento { get; set; }

    public long? IdSubDivision { get; set; }

    public long? IdDivision { get; set; }

    public double? Marca { get; set; }

    public string? Despro2 { get; set; }

    public string? Uniman { get; set; }

    public DateTime? Feccre { get; set; }

    public string? Colsab { get; set; }

    public string? Talla { get; set; }

    public double? Preven { get; set; }

    public double? Preven2 { get; set; }

    public double? Precos { get; set; }

    public double? Cospro { get; set; }

    public int? Exiqty { get; set; }

    public double? Exipdc { get; set; }

    public double? Exipdv { get; set; }

    public int? Exisic { get; set; }

    public DateTime? Fecsic { get; set; }

    public byte[]? Refer { get; set; }

    public string? Codcuedeb { get; set; }

    public string? Codcuehab { get; set; }

    public string? Codcuedes { get; set; }

    public string? Codcuedev { get; set; }

    public string? Iva { get; set; }

    public bool? PagaRegalia { get; set; }

    public string? Desind { get; set; }

    public string? Codorigen { get; set; }

    public double? Codcol { get; set; }

    public double? StockMax { get; set; }

    public double? StockMin { get; set; }

    public double? Espesor { get; set; }

    public double? Largo { get; set; }

    public double? Ancho { get; set; }

    public string? Fechacad { get; set; }

    public double? Fechacad1 { get; set; }

    public double? Fabricante { get; set; }

    public string? Obs { get; set; }

    public bool? Peso { get; set; }

    public DateTime? Fecing { get; set; }

    public double? ValorUnidad { get; set; }

    public string? Codsab { get; set; }

    public DateTime? Fechamod { get; set; }

    public string? Tamanio { get; set; }

    public string? Modelo { get; set; }

    public string? Numserie { get; set; }

    public string? Coleccion { get; set; }

    public string? Temporada { get; set; }

    public double? Prepormayor { get; set; }

    public double? PreAnterior { get; set; }

    public double? CosAnterior { get; set; }

    public double? DescCosto1 { get; set; }

    public double? DescCosto2 { get; set; }

    public double? DescCosto3 { get; set; }

    public double? DescCosto4 { get; set; }

    public double? Descuentos { get; set; }

    public double? PreRebaja { get; set; }

    public double? PreRebajaAntes { get; set; }

    public DateTime? FecIniPro { get; set; }

    public DateTime? FecFinPro { get; set; }

    public DateTime? FecIniPro1 { get; set; }

    public string? Codubi { get; set; }

    public DateTime? FecFinPro1 { get; set; }

    public DateTime? FecPreAct { get; set; }

    public DateTime? FecPreAnt { get; set; }

    public DateTime? FecPreMod { get; set; }

    public DateTime? FecCosAct { get; set; }

    public DateTime? FecCosMod { get; set; }

    public string? CodNiv { get; set; }

    public string? CodColUbi { get; set; }

    public double? MargenUtilidad { get; set; }

    public double? PvpSinIva { get; set; }

    public double? PorcenRecepcion { get; set; }

    public bool? Stocks { get; set; }

    public string? Abrevia { get; set; }

    public string? Referencia { get; set; }

    public double? MargenAntes { get; set; }

    public DateTime? FecMarAntes { get; set; }

    public bool? CantDecimal { get; set; }

    public double? CostSuminis { get; set; }

    public double? CantConv { get; set; }

    public double? CostHelado { get; set; }

    public bool? Receta { get; set; }

    public bool? Activo { get; set; }

    public string? ClasProd { get; set; }

    public string? Foto { get; set; }

    public bool? AltoRiesgo { get; set; }

    public bool? PGasto { get; set; }

    public string? CtaProdGasto { get; set; }

    public string? RegSanitario { get; set; }

    public long? EmpresaCodigo { get; set; }

    public long? IdDatosAdicionales { get; set; }

    public virtual Empresas? EmpresaCodigoNavigation { get; set; }

    public virtual ProductoDatosAdicionales? ProductoDatosAdicionales { get; set; }
}
