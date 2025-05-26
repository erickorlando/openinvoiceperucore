using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DatoAdicional
    {
        [JsonPropertyOrder(1)]
        public required string Codigo { get; set; }

        [JsonPropertyOrder(2)]
        public string Nombre { get; set; }

        [JsonPropertyOrder(3)]
        public required string Contenido { get; set; }

        [JsonPropertyOrder(4)]
        public string FechaInicio { get; set; }

        [JsonPropertyOrder(5)]
        public string FechaFin { get; set; }

        [JsonPropertyOrder(6)]
        public int Duracion { get; set; }
    }
}