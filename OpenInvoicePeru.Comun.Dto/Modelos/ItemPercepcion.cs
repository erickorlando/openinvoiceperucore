using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ItemPercepcion : ItemSunatBase
    {
        [JsonPropertyOrder(8)]
        [JsonPropertyName("ImporteSinPercepcion")]
        public required decimal ImporteSinPercepcion { get; set; }

        [JsonPropertyOrder(10)]
        [JsonPropertyName("ImportePercibido")]
        public required decimal ImportePercibido { get; set; }

        [JsonPropertyOrder(11)]
        [JsonPropertyName("FechaPercepcion")]
        public required string FechaPercepcion { get; set; }
    }
}