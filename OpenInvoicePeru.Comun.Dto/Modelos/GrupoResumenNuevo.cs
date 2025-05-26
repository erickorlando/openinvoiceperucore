using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GrupoResumenNuevo : GrupoResumen
    {
        [JsonPropertyName("IdDocumento")]
        public required string IdDocumento { get; set; }

        [JsonPropertyName("TipoDocumentoReceptor")]
        public required string TipoDocumentoReceptor { get; set; }

        [JsonPropertyName("NroDocumentoReceptor")]
        public required string NroDocumentoReceptor { get; set; }

        [JsonPropertyName("CodigoEstadoItem")]
        public required int CodigoEstadoItem { get; set; }

        public string DocumentoRelacionado { get; set; }

        public string TipoDocumentoRelacionado { get; set; }
    }
}