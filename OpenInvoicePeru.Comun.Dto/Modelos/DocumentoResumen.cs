using System.Text.Json.Serialization;
using OpenInvoicePeru.Comun.Dto.Contratos;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public abstract class DocumentoResumen : IDocumentoElectronico
    {
        [JsonPropertyName("IdDocumento")]
        public required string IdDocumento { get; set; }

        [JsonPropertyName("FechaEmision")]
        public required string FechaEmision { get; set; }

        [JsonPropertyName("FechaReferencia")]
        public required string FechaReferencia { get; set; }

        [JsonPropertyName("Emisor")]
        public required Contribuyente Emisor { get; set; }
    }
}