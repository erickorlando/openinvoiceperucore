using System;
using System.Text.Json.Serialization;
using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoElectronico : IDocumentoElectronico
    {

        [JsonPropertyName("IdDocumento")]
        public required string IdDocumento { get; set; }

        [JsonPropertyName("TipoDocumento")]
        public required string TipoDocumento { get; set; } // Initialized in constructor, but marked as required for consistency

        [JsonPropertyName("Emisor")]
        public required Compania Emisor { get; set; } // Initialized in constructor

        [JsonPropertyName("Receptor")]
        public required Compania Receptor { get; set; } // Initialized in constructor

        [JsonPropertyName("FechaEmision")]
        public required string FechaEmision { get; set; } // Initialized in constructor

        [JsonPropertyName("HoraEmision")]
        public required string HoraEmision { get; set; } // Initialized in constructor

        public string FechaVencimiento { get; set; }

        [JsonPropertyName("Moneda")]
        public required string Moneda { get; set; } // Initialized in constructor

        [JsonPropertyName("TipoOperacion")]
        public string TipoOperacion { get; set; } // Initialized in constructor

        public decimal Gravadas { get; set; }

        public decimal Gratuitas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exoneradas { get; set; }

        public decimal Exportacion { get; set; }

        public decimal DescuentoGlobal { get; set; }
        public decimal FactorMultiplicadorDscto { get; set; }
        public string CodigoRazonDcto { get; set; }
        public decimal MontoBaseParaDcto { get; set; }
        public decimal LineExtensionAmount { get; set; }
        public decimal TaxInclusiveAmount { get; set; }

        [JsonPropertyName("Items")]
        public required List<DetalleDocumento> Items { get; set; } // Initialized in constructor

        [JsonPropertyName("TotalVenta")]
        public decimal TotalVenta { get; set; }

        [JsonPropertyName("Redondeo")]
        public decimal Redondeo { get; set; }

        [JsonPropertyName("TotalIgv")]
        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosTributos { get; set; }

        public decimal TasaImpuesto { get; set; } // Initialized in constructor

        public string MontoEnLetras { get; set; }

        public decimal MontoPercepcion { get; set; }

        public decimal MontoDetraccion { get; set; }

        public decimal TasaDetraccion { get; set; }

        public string CuentaBancoNacion { get; set; }

        public string CodigoBienOServicio { get; set; }

        public string CodigoMedioPago { get; set; }

        public decimal MontoTotalAnticipo { get; set; }

        public bool Credito { get; set; }

        public List<DatoCredito> DatoCreditos { get; set; } // Initialized in constructor

        public List<DatoAdicional> DatoAdicionales { get; set; } // Initialized in constructor

        public List<Anticipo> Anticipos { get; set; } // Initialized in constructor

        public List<DocumentoRelacionado> Relacionados { get; set; } // Initialized in constructor

        public List<DocumentoRelacionado> OtrosDocumentosRelacionados { get; set; } // Initialized in constructor

        public List<Discrepancia> Discrepancias { get; set; } // Initialized in constructor

        public string NroOrdenCompra { get; set; }

        public string Notas { get; set; }

        public List<Leyenda> Leyendas { get; set; } // Initialized in constructor

        public decimal OtrosCargos { get; set; }

        public DocumentoElectronico()
        {
            Emisor = new Compania
            {
                TipoDocumento = "6", // RUC.
                NroDocumento = string.Empty, // Initialize required member
                NombreLegal = string.Empty,  // Initialize required member
                CodigoAnexo = "0000"       // Initialize required member
            };
            Receptor = new Compania
            {
                TipoDocumento = "6", // RUC.
                NroDocumento = string.Empty, // Initialize required member
                NombreLegal = string.Empty,  // Initialize required member
                CodigoAnexo = "0000"       // Initialize required member
            };
            Items = new List<DetalleDocumento>();
            DatoAdicionales = new List<DatoAdicional>();
            Relacionados = new List<DocumentoRelacionado>();
            OtrosDocumentosRelacionados = new List<DocumentoRelacionado>();
            Leyendas = new List<Leyenda>();
            Discrepancias = new List<Discrepancia>();
            Anticipos = new List<Anticipo>();
            DatoCreditos = new List<DatoCredito>();
            TipoDocumento = "01"; // Factura.
            TipoOperacion = "0101"; // Venta Interna.
            Moneda = "PEN"; // Soles.
            TasaImpuesto = 0.18m;
            FechaEmision = DateTime.Today.ToString("yyyy-MM-dd");
            HoraEmision = DateTime.Now.ToString("HH:mm:ss");
            
        }
    }
}