using System.Text.Json.Serialization;

namespace clientes_ms.Application.Records.Request
{
    //Crear los Request con su constructor para poder enviar los datos como un JSON siempre
    public record GrupoProductoRequest
    {
        [JsonPropertyName("id_grupo_empresa")]
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

        public GrupoProductoRequest() { }
        public GrupoProductoRequest(long IdGrupoProducto, string Codigo, string Descripcion,
    string Segmento, string DesSegmento, string Familia, string DesFamilia,
    string Clase, string DesClase, string Brick, string DesBrick,
    string DesSegmentoing, string DesFamiliaing, string DesClaseing, string DesBricking)
        {
            this.IdGrupoProducto = IdGrupoProducto;
            this.IdGrupoProducto = IdGrupoProducto;    
            this.Codigo = Codigo.Trim();
            this.Descripcion = Descripcion.Trim();
            this.Segmento = Segmento.Trim();
            this.DesSegmento = DesSegmento.Trim();
            this.Familia = Familia.Trim();
            this.DesFamilia = DesFamilia.Trim();
            this.Clase = Clase.Trim();
            this.DesClase = DesClase.Trim();
            this.Brick = Brick.Trim();
            this.DesBrick = DesBrick.Trim();
            this.DesSegmentoing = DesSegmentoing.Trim();
            this.DesFamiliaing = DesFamiliaing.Trim();
            this.DesClaseing = DesClaseing.Trim();
            this.DesBricking = DesBricking.Trim();


        }
    }

}
