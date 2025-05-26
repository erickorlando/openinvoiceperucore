using System.Text.Json.Serialization;
using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GuiaRemision : IDocumentoElectronico
    {
        [JsonPropertyName("IdDocumento")]
        public required string IdDocumento { get; set; }

        [JsonPropertyName("FechaEmision")]
        public required string FechaEmision { get; set; }

        [JsonPropertyName("TipoDocumento")]
        public required string TipoDocumento { get; set; }

        [JsonPropertyName("Glosa")]
        public string Glosa { get; set; }

        [JsonPropertyName("Remitente")]
        public required Contribuyente Remitente { get; set; }

        [JsonPropertyName("Destinatario")]
        public required Contribuyente Destinatario { get; set; }

        [JsonPropertyName("Tercero")]
        public Contribuyente Tercero { get; set; } // Marked as required previously, but Contribuyente can be complex. Assuming it can be null based on typical usage. If strictly required, add 'required'.

        [JsonPropertyName("DocumentoRelacionado")]
        public DocumentoRelacionado DocumentoRelacionado { get; set; }

        [JsonPropertyName("GuiaBaja")]
        public DocumentoRelacionado GuiaBaja { get; set; }

        [JsonPropertyName("CodigoMotivoTraslado")]
        public required string CodigoMotivoTraslado { get; set; }

        [JsonPropertyName("DescripcionMotivo")]
        public required string DescripcionMotivo { get; set; }

        [JsonPropertyName("Transbordo")]
        public required bool Transbordo { get; set; }

        [JsonPropertyName("PesoBrutoTotal")]
        public required decimal PesoBrutoTotal { get; set; }

        public int NroPallets { get; set; }

        [JsonPropertyName("ModalidadTraslado")]
        public required string ModalidadTraslado { get; set; }

        [JsonPropertyName("FechaInicioTraslado")]
        public required string FechaInicioTraslado { get; set; }

        public string RucTransportista { get; set; }

        public string RazonSocialTransportista { get; set; }

        public string NroPlacaVehiculo { get; set; }

        public string NroDocumentoConductor { get; set; }

        [JsonPropertyName("DireccionPartida")]
        public required Direccion DireccionPartida { get; set; }

        [JsonPropertyName("DireccionLlegada")]
        public required Direccion DireccionLlegada { get; set; }

        public string NumeroContenedor { get; set; }

        public string CodigoPuerto { get; set; }

        [JsonPropertyName("BienesATransportar")]
        public required List<DetalleGuia> BienesATransportar { get; set; }

        public string ShipmentId { get; set; }
    }
}