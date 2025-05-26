using System.Text.Json.Serialization;

namespace OpenInvoicePeru.Servicio.ApiSunatDto
{
    public class TokenResponseDto
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int Expires { get; set; }
    }
}