using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class ConsultaConstanciaRequest : EnvioDocumentoComun
    {
        [JsonPropertyName("Serie")]
        public string Serie { get; set; }

        [JsonPropertyName("Numero")]
        public int Numero { get; set; }
    }
}