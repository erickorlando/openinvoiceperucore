using System.Text.Json.Serialization;
using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoRetencion : DocumentoSunatBase, IDocumentoElectronico
    {
        [JsonPropertyOrder(7)]
        public required string RegimenRetencion { get; set; }

        [JsonPropertyOrder(8)]
        public required decimal TasaRetencion { get; set; }

        [JsonPropertyOrder(9)]
        public required decimal ImporteTotalRetenido { get; set; }

        [JsonPropertyOrder(10)]
        public required decimal ImporteTotalPagado { get; set; }

        [JsonPropertyOrder(11)]
        public required List<ItemRetencion> DocumentosRelacionados { get; set; }
    }
}