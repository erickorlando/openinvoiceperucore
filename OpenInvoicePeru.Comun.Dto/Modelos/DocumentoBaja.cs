using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoBaja : DocumentoResumenDetalle
    {
        [JsonPropertyName("Correlativo")]
        public required string Correlativo { get; set; }

        [JsonPropertyName("MotivoBaja")]
        public required string MotivoBaja { get; set; }
    }
}