using OpenInvoicePeru.Servicio.ApiSunatDto;
using RestSharp;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenInvoicePeru.Servicio
{
    public class ValidezComprobanteHelper : IValidezComprobanteHelper
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            // DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // Example if needed
            // PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Example if needed
        };

        public async Task<BaseResponseDto<TokenResponseDto>> GenerarToken(string clientId, string clientSecret)
        {
            var response = new BaseResponseDto<TokenResponseDto>();

            try
            {
                var restClient = new RestClient($"https://api-seguridad.sunat.gob.pe/v1/clientesextranet/{clientId}/oauth2/token");

                var restRequest = new RestRequest(Method.POST);

                var formUrlencoded = "application/x-www-form-urlencoded";
                var grandType = "client_credentials";
                var scope = "https://api.sunat.gob.pe/v1/contribuyente/contribuyentes";

                restRequest.AddHeader("Content-Type", formUrlencoded);

                restRequest.AddParameter(formUrlencoded,
                    $"grant_type={grandType}&scope={scope}&client_id={clientId}&client_secret={clientSecret}", ParameterType.RequestBody);

                // This part uses RestSharp's internal deserialization, which might still use Newtonsoft by default for v106.
                // If TokenResponseDto has System.Text.Json attributes, RestSharp might not use them automatically with default setup.
                // However, if TokenResponseDto is simple and casing matches, it might work.
                var responseMessage = await restClient.ExecutePostAsync<TokenResponseDto>(restRequest);

                response.Success = responseMessage.IsSuccessful;

                if (responseMessage.IsSuccessful)
                {
                    response.Result = responseMessage.Data;
                }
                else
                {
                    response.ErrorMessage = responseMessage.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ValidacionResponse> Validar(string rucReceptor, string token, ValidacionRequest request)
        {
            var response = new ValidacionResponse();

            try
            {
                var restClient = new RestClient($"https://api.sunat.gob.pe/v1/contribuyente/contribuyentes/{rucReceptor}/validarcomprobante");

                var restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Authorization", $"Bearer {token}");
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json",
                    JsonSerializer.Serialize(request, _jsonSerializerOptions),
                    ParameterType.RequestBody);

                var result = await restClient.ExecuteAsync(restRequest);
                response.Success = result.IsSuccessful;

                if (result.IsSuccessful && !string.IsNullOrEmpty(result.Content))
                {
                    var deserializedResponse = JsonSerializer.Deserialize<ValidacionResponse>(result.Content, _jsonSerializerOptions);
                    if (deserializedResponse != null)
                    {
                        response = deserializedResponse;
                        response.Success = true; // Ensure success is propagated from the deserialized object if not set
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Failed to deserialize response content.";
                    }
                }
                else if (!result.IsSuccessful)
                {
                    response.Message = result.Content; // Contains error message from server or RestSharp
                    if (string.IsNullOrEmpty(response.Message) && result.ErrorMessage != null)
                    {
                        response.Message = result.ErrorMessage;
                    }
                }
                else // Successful HTTP request but empty content
                {
                    response.Success = false;
                    response.Message = "Received successful HTTP response with empty content.";
                }
            }
            catch (JsonException jsonEx) // Catch specific JsonException
            {
                response.Success = false;
                response.Message = $"JSON Deserialization Error: {jsonEx.Message}";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
