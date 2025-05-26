using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ComunicacionBaja : DocumentoResumen
    {
        [JsonPropertyName("Bajas")]
        public List<DocumentoBaja> Bajas { get; set; }
    }
}