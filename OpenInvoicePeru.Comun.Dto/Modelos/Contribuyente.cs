using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Contribuyente
    {

        [JsonPropertyOrder(1)]
        public required string NroDocumento { get; set; }

        [JsonPropertyOrder(2)]
        public required string TipoDocumento { get; set; }

        [JsonPropertyOrder(3)]
        public required string NombreLegal { get; set; }

        [JsonPropertyOrder(4)]
        public string NombreComercial { get; set; }

    }
}