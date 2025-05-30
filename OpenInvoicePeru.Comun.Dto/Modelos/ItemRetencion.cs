using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ItemRetencion : ItemSunatBase
    {
        [JsonPropertyOrder(8)]
        [JsonPropertyName("ImporteSinRetencion")]
        public required decimal ImporteSinRetencion { get; set; }

        [JsonPropertyOrder(10)]
        [JsonPropertyName("ImporteRetenido")]
        public required decimal ImporteRetenido { get; set; }

        [JsonPropertyOrder(11)]
        [JsonPropertyName("FechaRetencion")]
        public required string FechaRetencion { get; set; }
    }
}