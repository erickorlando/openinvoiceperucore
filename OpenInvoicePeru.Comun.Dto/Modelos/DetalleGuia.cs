using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DetalleGuia
    {
        [JsonPropertyName("Correlativo")]
        public required int Correlativo { get; set; }

        [JsonPropertyName("CodigoItem")]
        public required string CodigoItem { get; set; }

        [JsonPropertyName("Descripcion")]
        public required string Descripcion { get; set; }

        [JsonPropertyName("UnidadMedida")]
        public required string UnidadMedida { get; set; }

        [JsonPropertyName("Cantidad")]
        public required decimal Cantidad { get; set; }

        public int LineaReferencia { get; set; }
    }
}