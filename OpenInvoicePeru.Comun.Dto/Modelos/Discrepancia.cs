using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Discrepancia
    {
        [JsonPropertyName("NroReferencia")]
        public required string NroReferencia { get; set; }

        [JsonPropertyName("Tipo")]
        public required string Tipo { get; set; }

        [JsonPropertyName("Descripcion")]
        [StringLength(500)]
        public required string Descripcion { get; set; }
    }
}