using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoRelacionado
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("NroDocumento")]
        public required string NroDocumento { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("TipoDocumento")]
        public required string TipoDocumento { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("DescripcionTipoDocumento")]
        public string DescripcionTipoDocumento { get; set; }
    }
}