using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Response
{
    public record GrupoProductoResponse
    {
        [JsonPropertyName("id_grupo_producto")]
        public long IdGrupoProducto { get; set; }

        [JsonPropertyName("codigo")]
        public string Codigo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;
        public string Segmento { get; set; } = string.Empty;
        public string DesSegmento { get; set; } = string.Empty;
        public string Familia { get; set; } = string.Empty;
        public string DesFamilia { get; set; } = string.Empty;
        public string Clase { get; set; } = string.Empty;
        public string DesClase { get; set; } = string.Empty;
        public string Brick { get; set; } = string.Empty;
        public string DesBrick { get; set; } = string.Empty;
        public string DesSegmentoing { get; set; } = string.Empty;
        public string DesFamiliaing { get; set; } = string.Empty;
        public string DesClaseing { get; set; } = string.Empty;
        public string DesBricking { get; set; } = string.Empty;
        public string BrickIncludes { get; set; } = string.Empty;
        public string BrickExcludes { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;

        public GrupoProductoResponse() { }

        public GrupoProductoResponse(
            long idGrupoProducto,
            string codigo,
            string descripcion,
            string segmento,
            string desSegmento,
            string familia,
            string desFamilia,
            string clase,
            string desClase,
            string brick,
            string desBrick,
            string desSegmentoing,
            string desFamiliaing,
            string desClaseing,
            string desBricking,
            string brickIncludes,
            string brickExcludes,
            bool estado)
        {
            IdGrupoProducto = idGrupoProducto;
            Codigo = codigo?.Trim() ?? string.Empty;
            Descripcion = descripcion?.Trim() ?? string.Empty;
            Segmento = segmento?.Trim() ?? string.Empty;
            DesSegmento = desSegmento?.Trim() ?? string.Empty;
            Familia = familia?.Trim() ?? string.Empty;
            DesFamilia = desFamilia?.Trim() ?? string.Empty;
            Clase = clase?.Trim() ?? string.Empty;
            DesClase = desClase?.Trim() ?? string.Empty;
            Brick = brick?.Trim() ?? string.Empty;
            DesBrick = desBrick?.Trim() ?? string.Empty;
            DesSegmentoing = desSegmentoing?.Trim() ?? string.Empty;
            DesFamiliaing = desFamiliaing?.Trim() ?? string.Empty;
            DesClaseing = desClaseing?.Trim() ?? string.Empty;
            DesBricking = desBricking?.Trim() ?? string.Empty;
            BrickIncludes = brickIncludes?.Trim() ?? string.Empty;
            BrickExcludes = brickExcludes?.Trim() ?? string.Empty;
            Estado = estado;
        }
    }
}
