using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public abstract class EnvioDocumentoComun
    {
        [JsonPropertyName("Ruc")]
        public string Ruc { get; set; }

        [JsonPropertyName("UsuarioSol")]
        public string UsuarioSol { get; set; }

        [JsonPropertyName("ClaveSol")]
        public string ClaveSol { get; set; }

        [JsonPropertyName("IdDocumento")]
        public string IdDocumento { get; set; }

        [JsonPropertyName("TipoDocumento")]
        public string TipoDocumento { get; set; }

        [JsonPropertyName("EndPointUrl")]
        public string EndPointUrl { get; set; }
    }
}