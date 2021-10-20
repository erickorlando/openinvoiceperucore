﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DetalleDocumento
    {
        [JsonProperty(Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Cantidad { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string UnidadMedida { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string CodigoItem { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Descripcion { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PrecioUnitario { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PrecioReferencial { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoPrecio { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoImpuesto { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Impuesto { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public decimal? BaseImponible { get; set; }

        public decimal ImpuestoSelectivo { get; set; }

        public decimal TasaImpuestoSelectivo { get; set; }

        public decimal OtroImpuesto { get; set; }
        public int CantidadBolsas { get; set; }
        public decimal PrecioUnitarioBolsa { get; set; }

        public decimal Descuento { get; set; }

        public string PlacaVehiculo { get; set; }

        public string CodigoProductoSunat { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalVenta { get; set; }

        public List<DatoAdicional> DatosAdicionales { get; set; }
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
        public int Referencia { get; set; }

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