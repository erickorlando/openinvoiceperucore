using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class FirmadoRequest
    {
        [JsonPropertyName("CertificadoDigital")]
        public string CertificadoDigital { get; set; }

        [JsonPropertyName("PasswordCertificado")]
        public string PasswordCertificado { get; set; }

        [JsonPropertyName("TramaXmlSinFirma")]
        public string TramaXmlSinFirma { get; set; }

        [JsonPropertyName("ValoresQr")]
        public string ValoresQr { get; set; }
    }
}