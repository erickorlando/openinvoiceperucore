using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoSunatBase
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("IdDocumento")]
        public required string IdDocumento { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("FechaEmision")]
        public required string FechaEmision { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("Emisor")]
        public required Negocio Emisor { get; set; }

        [JsonPropertyOrder(4)]
        [JsonPropertyName("Receptor")]
        public required Negocio Receptor { get; set; }

        [JsonPropertyOrder(5)]
        [JsonPropertyName("Moneda")]
        public required string Moneda { get; set; }

        [JsonPropertyOrder(6)]
        [JsonPropertyName("Observaciones")]
        public string Observaciones { get; set; }
    }
}