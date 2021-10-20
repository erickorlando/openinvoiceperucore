using Microsoft.AspNetCore.Mvc;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.WebApi.Utils;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace OpenInvoicePeru.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirmarController : ControllerBase
    {
        private readonly ICertificador _certificador;

        public FirmarController(ICertificador certificador)
        {
            _certificador = certificador;
        }

        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(FirmadoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> Post([FromBody]FirmadoRequest request)
        {
            var response = new FirmadoResponse();

            try
            {
                response = await _certificador.FirmarXml(request);
                response.Exito = true;
                if (!string.IsNullOrEmpty(request.ValoresQr))
                    response.CodigoQr = QrHelper.GenerarImagenQr($"{request.ValoresQr}{response.ResumenFirma}");
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }
    }
}