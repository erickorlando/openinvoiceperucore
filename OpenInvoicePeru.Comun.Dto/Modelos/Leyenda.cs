using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Leyenda
    {
        [JsonPropertyName("Codigo")]
        public required string Codigo { get; set; }

        [JsonPropertyName("Descripcion")]
        public required string Descripcion { get; set; }
    }
}