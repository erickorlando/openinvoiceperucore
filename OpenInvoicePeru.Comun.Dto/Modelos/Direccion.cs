using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Direccion
    {
        [JsonPropertyName("Ubigeo")]
        public required string Ubigeo { get; set; }

        [JsonPropertyName("DireccionCompleta")]
        public required string DireccionCompleta { get; set; }
    }
}