using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Compania : Contribuyente
    {
        [JsonPropertyOrder(5)]
        public required string CodigoAnexo { get; set; }
    }
}