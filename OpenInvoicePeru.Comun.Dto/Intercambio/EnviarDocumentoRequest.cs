using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class EnviarDocumentoRequest : EnvioDocumentoComun
    {
        [JsonPropertyName("TramaXmlFirmado")]
        public string TramaXmlFirmado { get; set; }

    }
}