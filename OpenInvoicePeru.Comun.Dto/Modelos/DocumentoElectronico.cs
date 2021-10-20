﻿using System;
using Newtonsoft.Json;
using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoElectronico : IDocumentoElectronico
    {

        [JsonProperty(Required = Required.Always)]
        public string IdDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Compania Emisor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Compania Receptor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaEmision { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string HoraEmision { get; set; }

        public string FechaVencimiento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Moneda { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string TipoOperacion { get; set; }

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

        [JsonProperty(Required = Required.Always)]
        public List<DetalleDocumento> Items { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalVenta { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public decimal Redondeo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosTributos { get; set; }

        public decimal TasaImpuesto { get; set; }

        public string MontoEnLetras { get; set; }

        public decimal MontoPercepcion { get; set; }

        public decimal MontoDetraccion { get; set; }

        public decimal TasaDetraccion { get; set; }

        public string CuentaBancoNacion { get; set; }

        public string CodigoBienOServicio { get; set; }

        public string CodigoMedioPago { get; set; }

        public decimal MontoTotalAnticipo { get; set; }

        public bool Credito { get; set; }

        public List<DatoCredito> DatoCreditos { get; set; }

        public List<DatoAdicional> DatoAdicionales { get; set; }

        public List<Anticipo> Anticipos { get; set; }

        public List<DocumentoRelacionado> Relacionados { get; set; }

        public List<DocumentoRelacionado> OtrosDocumentosRelacionados { get; set; }

        public List<Discrepancia> Discrepancias { get; set; }

        public string NroOrdenCompra { get; set; }

        public string Notas { get; set; }

        public List<Leyenda> Leyendas { get; set; }

        public decimal OtrosCargos { get; set; }

        public DocumentoElectronico()
        {
            Emisor = new Compania
            {
                TipoDocumento = "6" // RUC.
            };
            Receptor = new Compania
            {
                TipoDocumento = "6" // RUC.
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