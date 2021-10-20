﻿using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;
using System.Collections.Generic;

namespace OpenInvoicePeru.Xml
{
    public class TotalesDto
    {
        public decimal Monto { get; set; }
        public decimal MontoBase { get; set; }
        public string CurrencyId { get; set; }
        public string CategoryId { get; set; }
        public string TaxSchemeId { get; set; }
        public string Name { get; set; }
        public string TaxTypeCode { get; set; }
        public string TaxExemptionReasonCode { get; set; }
        public decimal TaxPercent { get; set; }
        public int CantidadBolsas { get; set; }
        public decimal PrecioUnitarioBolsa { get; set; }
    }

    public static class CalculoTotales
    {

        public static List<TaxSubtotal> AgregarSubTotalCabecera(TotalesDto totalesDto)
        {
            return new List<TaxSubtotal>
            {
                new TaxSubtotal
                {
                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = totalesDto.CurrencyId,
                        Value = totalesDto.MontoBase
                    },
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = totalesDto.CurrencyId,
                        Value = totalesDto.Monto,
                    },
                    TaxCategory = new TaxCategory
                    {
                        Id = totalesDto.CategoryId == "Z" ? string.Empty : totalesDto.CategoryId,
                        TaxScheme = new TaxScheme
                        {
                            Id = totalesDto.TaxSchemeId,
                            Name = totalesDto.Name,
                            TaxTypeCode = totalesDto.TaxTypeCode
                        }
                    }
                }
            };
        }

        public static List<TaxSubtotal> AgregarSubTotalDetalles(TotalesDto totalesDto)
        {
            return new List<TaxSubtotal>
            {
                new TaxSubtotal
                {
                    TaxableAmount = new PayableAmount
                    {
                        CurrencyId = totalesDto.CurrencyId,
                        Value = totalesDto.MontoBase
                    },
                    TaxAmount = new PayableAmount
                    {
                        CurrencyId = totalesDto.CurrencyId,
                        Value = totalesDto.Monto,
                    },
                    TaxCategory = new TaxCategory
                    {
                        Id = totalesDto.CategoryId,
                        PerUnitAmount = new PayableAmount
                        {
                            CurrencyId = totalesDto.CurrencyId,
                            Value = totalesDto.PrecioUnitarioBolsa
                        },
                        Percent = totalesDto.TaxPercent,
                        TaxExemptionReasonCode = totalesDto.TaxExemptionReasonCode,
                        TierRange = totalesDto.Name == "ISC" ? "03" : string.Empty,
                        TaxScheme = new TaxScheme
                        {
                            Id = totalesDto.TaxSchemeId,
                            Name = totalesDto.Name,
                            TaxTypeCode = totalesDto.TaxTypeCode
                        }
                    },
                    BaseUnitMeasure = new InvoicedQuantity
                    {
                        UnitCode = "NIU",
                        Value = totalesDto.CantidadBolsas
                    }
                }
            };
        }

    }
}