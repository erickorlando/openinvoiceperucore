using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class ConsultaTicketRequest : EnvioDocumentoComun
    {
        [JsonPropertyName("NroTicket")]
        public string NroTicket { get; set; }
    }
}