using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public abstract class DocumentoResumenDetalle
    {
        [JsonPropertyName("Id")]
        public required int Id { get; set; }

        [JsonPropertyName("TipoDocumento")]
        public required string TipoDocumento { get; set; }

        [JsonPropertyName("Serie")]
        public required string Serie { get; set; }
    }
}