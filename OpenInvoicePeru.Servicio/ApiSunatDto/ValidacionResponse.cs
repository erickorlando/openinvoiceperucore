using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Servicio.ApiSunatDto
{
    public class ValidacionResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("estadoCp")]
        public string EstadoComprobante { get; set; }

        [JsonPropertyName("estadoRuc")]
        public string EstadoRuc { get; set; }

        [JsonPropertyName("condDomiRuc")]
        public string CondicionDomicilio { get; set; }

        [JsonPropertyName("observaciones")]
        public ICollection<string> Observaciones { get; set; }
    }
}