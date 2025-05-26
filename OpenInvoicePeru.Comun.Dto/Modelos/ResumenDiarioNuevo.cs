using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ResumenDiarioNuevo : DocumentoResumen
    {
        [JsonPropertyName("Resumenes")]
        public required List<GrupoResumenNuevo> Resumenes { get; set; }
    }
}