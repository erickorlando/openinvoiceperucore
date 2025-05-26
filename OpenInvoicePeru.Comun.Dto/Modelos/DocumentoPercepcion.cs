using System.Text.Json.Serialization;
using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoPercepcion : DocumentoSunatBase, IDocumentoElectronico
    {
        [JsonPropertyOrder(7)]
        public required string RegimenPercepcion { get; set; }

        [JsonPropertyOrder(8)]
        public required decimal TasaPercepcion { get; set; }

        [JsonPropertyOrder(9)]
        public required decimal ImporteTotalPercibido { get; set; }

        [JsonPropertyOrder(10)]
        public required decimal ImporteTotalCobrado { get; set; }

        [JsonPropertyOrder(11)]
        public required List<ItemPercepcion> DocumentosRelacionados { get; set; }
    }
}