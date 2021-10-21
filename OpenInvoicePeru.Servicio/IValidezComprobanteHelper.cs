using System.Threading.Tasks;
using OpenInvoicePeru.Servicio.ApiSunatDto;

namespace OpenInvoicePeru.Servicio
{
    public interface IValidezComprobanteHelper
    {
        Task<BaseResponseDto<TokenResponseDto>> GenerarToken(string clientId, string clientSecret);
        Task<ValidacionResponse> Validar(string rucReceptor, string token, ValidacionRequest request);
    }
}