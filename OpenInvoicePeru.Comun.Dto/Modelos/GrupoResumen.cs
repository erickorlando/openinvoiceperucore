using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GrupoResumen : DocumentoResumenDetalle
    {
        public int CorrelativoInicio { get; set; }

        public int CorrelativoFin { get; set; }

        [JsonPropertyName("Moneda")]
        public required string Moneda { get; set; }

        [JsonPropertyName("TotalVenta")]
        public required decimal TotalVenta { get; set; }

        public decimal TotalDescuentos { get; set; }

        [JsonPropertyName("TotalIgv")]
        public required decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosImpuestos { get; set; }

        public decimal TotalImpuestoBolsas { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Exoneradas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exportacion { get; set; }

        public decimal Gratuitas { get; set; }
    }
}