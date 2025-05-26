using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Servicio.ApiSunatDto
{
    public class ValidacionRequest
    {
        [JsonPropertyName("numRuc")]
        public string RucEmisor { get; set; }
        
        [JsonPropertyName("codComp")]
        public string CodigoComprobante { get; set; }
        
        [JsonPropertyName("numeroSerie")]
        public string NumeroSerie { get; set; }
        
        [JsonPropertyName("numero")]
        public int Numero { get; set; }

        [JsonPropertyName("fechaEmision")]
        public string FechaEmision { get; set; }

        [JsonPropertyName("monto")]
        public decimal Monto { get; set; }
    }
}