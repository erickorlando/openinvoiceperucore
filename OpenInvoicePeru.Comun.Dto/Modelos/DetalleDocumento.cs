using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DetalleDocumento
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; } // Initialized in constructor

        [JsonPropertyName("Cantidad")]
        public decimal Cantidad { get; set; }

        [JsonPropertyName("UnidadMedida")]
        public string UnidadMedida { get; set; } // Initialized in constructor

        [JsonPropertyName("CodigoItem")]
        public string CodigoItem { get; set; }

        [JsonPropertyName("Descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("PrecioUnitario")]
        public decimal PrecioUnitario { get; set; }

        [JsonPropertyName("PrecioReferencial")]
        public decimal PrecioReferencial { get; set; }

        [JsonPropertyName("TipoPrecio")]
        public string TipoPrecio { get; set; } // Initialized in constructor

        [JsonPropertyName("TipoImpuesto")]
        public string TipoImpuesto { get; set; } // Initialized in constructor

        [JsonPropertyName("Impuesto")]
        public decimal Impuesto { get; set; }

        [JsonPropertyName("BaseImponible")]
        public decimal? BaseImponible { get; set; }

        public decimal ImpuestoSelectivo { get; set; }

        public decimal TasaImpuestoSelectivo { get; set; }

        public decimal OtroImpuesto { get; set; }
        public int CantidadBolsas { get; set; }
        public decimal PrecioUnitarioBolsa { get; set; }

        public decimal Descuento { get; set; }

        public string PlacaVehiculo { get; set; }

        public string CodigoProductoSunat { get; set; }

        [JsonPropertyName("TotalVenta")]
        public decimal TotalVenta { get; set; }

        public List<DatoAdicional> DatosAdicionales { get; set; } // Initialized in constructor
        public string UbigeoOrigen { get; set; }
        public string DireccionOrigen { get; set; }
        public string UbigeoDestino { get; set; }
        public string DireccionDestino { get; set; }
        public string DetalleViaje { get; set; }
        public decimal ValorReferencial { get; set; }
        public decimal ValorReferencialCargaEfectiva { get; set; }
        public decimal ValorReferencialCargaUtil { get; set; }
        public string ConfiguracionVehicular { get; set; }
        public decimal CargaUtil { get; set; }
        public decimal CargaEfectiva { get; set; }
        public decimal ValorReferencialTm { get; set; }
        public decimal ValorPreliminarReferencial { get; set; }
        public bool ViajeConRetorno { get; set; }
        public int Referencia { get; set; } // Initialized in constructor

        public DetalleDocumento()
        {
            Id = 1;
            UnidadMedida = "NIU";
            TipoPrecio = "01";
            TipoImpuesto = "10";
            Referencia = 0;
            DatosAdicionales = new List<DatoAdicional>();
        }
    }
}