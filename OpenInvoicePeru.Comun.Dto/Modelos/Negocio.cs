using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Negocio : Contribuyente
    {
        [JsonPropertyOrder(6)]
        [JsonPropertyName("Ubigeo")]
        public string Ubigeo { get; set; }

        [JsonPropertyOrder(7)]
        [JsonPropertyName("Direccion")]
        public string Direccion { get; set; }

        [JsonPropertyOrder(8)]
        [JsonPropertyName("Urbanizacion")]
        public string Urbanizacion { get; set; }

        [JsonPropertyOrder(9)]
        [JsonPropertyName("Departamento")]
        public string Departamento { get; set; }

        [JsonPropertyOrder(10)]
        [JsonPropertyName("Provincia")]
        public string Provincia { get; set; }

        [JsonPropertyOrder(11)]
        [JsonPropertyName("Distrito")]
        public string Distrito { get; set; }
    }
}