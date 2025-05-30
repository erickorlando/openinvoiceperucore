using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ResumenDiario : DocumentoResumen
    {
        [JsonPropertyName("Resumenes")]
        public required List<GrupoResumen> Resumenes { get; set; }
    }
}