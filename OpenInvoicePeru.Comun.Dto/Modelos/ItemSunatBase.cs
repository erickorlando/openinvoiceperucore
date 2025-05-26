using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ItemSunatBase : DocumentoRelacionado
    {
        [JsonPropertyOrder(3)]
        [JsonPropertyName("FechaEmision")]
        public required string FechaEmision { get; set; }

        [JsonPropertyOrder(4)]
        [JsonPropertyName("ImporteTotal")]
        public required decimal ImporteTotal { get; set; }

        [JsonPropertyOrder(5)]
        [JsonPropertyName("MonedaDocumentoRelacionado")]
        public required string MonedaDocumentoRelacionado { get; set; }

        [JsonPropertyOrder(6)]
        [JsonPropertyName("NumeroPago")]
        public required int NumeroPago { get; set; }

        [JsonPropertyOrder(7)]
        [JsonPropertyName("ImporteTotalNeto")]
        public required decimal ImporteTotalNeto { get; set; }

        [JsonPropertyOrder(9)]
        [JsonPropertyName("FechaPago")]
        public required string FechaPago { get; set; }

        [JsonPropertyOrder(12)]
        [JsonPropertyName("TipoCambio")]
        public decimal TipoCambio { get; set; }

        [JsonPropertyOrder(13)]
        [JsonPropertyName("FechaTipoCambio")]
        public string FechaTipoCambio { get; set; }
    }
}