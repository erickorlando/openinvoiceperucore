using Microsoft.AspNetCore.Mvc;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Servicio;
using OpenInvoicePeru.WebApi.Utils;
using OpenInvoicePeru.Xml;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace OpenInvoicePeru.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {
        private readonly ISerializador _serializador;
        private readonly ICertificador _certificador;
        private readonly IServicioSunatDocumentos _servicioSunatDocumentos;
        private readonly IServicioSunatConsultas _servicioSunatConsultas;

        public ComprobanteController(ISerializador serializador,
            IServicioSunatDocumentos servicioSunatDocumentos,
            ICertificador certificador,
            IServicioSunatConsultas servicioSunatConsultas)
        {
            _serializador = serializador;
            _servicioSunatDocumentos = servicioSunatDocumentos;
            _certificador = certificador;
            _servicioSunatConsultas = servicioSunatConsultas;
        }

        /// <summary>
        /// Generar el XML para Factura, Boleta, Nota Credito o Debito.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(DocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> GenerarCpe([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                IDocumentoXml result;
                switch (documento.TipoDocumento)
                {
                    case "01":
                    case "03":
                        result = new FacturaXml();
                        break;
                    case "07":
                        result = new NotaCreditoXml();
                        break;
                    case "08":
                        result = new NotaDebitoXml();
                        break;
                    default:
                        result = new FacturaXml();
                        break;
                }

                var documentoXml = result;

                var invoice = documentoXml.Generar(documento);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(invoice);
                var serieCorrelativo = documento.IdDocumento.Split('-');
                response.ValoresParaQr =
                    $"{documento.Emisor.NroDocumento}|{documento.TipoDocumento}|{serieCorrelativo[0]}|{serieCorrelativo[1]}|{documento.TotalIgv:N2}|{documento.TotalVenta:N2}|{Convert.ToDateTime(documento.FechaEmision):yyyy-MM-dd}|{documento.Receptor.TipoDocumento}|{documento.Receptor.NroDocumento}|";

                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// Genera la Comunicacion de Baja.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(DocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> GenerarComunicacionBaja([FromBody] ComunicacionBaja baja)
        {
            var response = new DocumentoResponse();

            try
            {
                var voidedDocument = new ComunicacionBajaXml().Generar(baja);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(voidedDocument);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// Genera el XML para el Resumen Diario
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(DocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> GenerarResumenDiario([FromBody] ResumenDiarioNuevo resumen)
        {
            var response = new DocumentoResponse();
            try
            {
                var summary = new ResumenDiarioNuevoXml().Generar(resumen);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(summary);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
            }

            return Ok(response);
        }

        /// <summary>
        /// Genera el XML para la Retencion
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(DocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> GenerarRetencion([FromBody] DocumentoRetencion documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var invoice = new RetencionXml().Generar(documento);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(invoice);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// Genera el XML para la Percepcion
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(DocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> GenerarPercepcion([FromBody] DocumentoPercepcion documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var invoice = new PercepcionXml().Generar(documento);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(invoice);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// Consulta el Ticket existen en SUNAT (Solo Produccion)
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(EnviarDocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> ConsultarTicket([FromBody] ConsultaTicketRequest request)
        {
            var response = new EnviarDocumentoResponse();

            try
            {
                _servicioSunatDocumentos.Inicializar(new ParametrosConexion
                {
                    Ruc = request.Ruc,
                    UserName = request.UsuarioSol,
                    Password = request.ClaveSol,
                    EndPointUrl = request.EndPointUrl
                });

                var resultado = await _servicioSunatDocumentos.ConsultarTicket(request.NroTicket);

                if (!resultado.Exito)
                {
                    response.Exito = false;
                    response.MensajeError = resultado.MensajeError;
                }
                else
                    response = await _serializador.GenerarDocumentoRespuesta(resultado.ConstanciaDeRecepcion);
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Source == "DotNetZip" ? "El Ticket no existe" : ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// Consulta el CDR existente en SUNAT (solo Produccion)
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(EnviarDocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> ConsultarConstancia([FromBody] ConsultaConstanciaRequest request)
        {
            var response = new EnviarDocumentoResponse();

            try
            {
                _servicioSunatConsultas.Inicializar(new ParametrosConexion
                {
                    Ruc = request.Ruc,
                    UserName = request.UsuarioSol,
                    Password = request.ClaveSol,
                    EndPointUrl = request.EndPointUrl
                });

                var resultado = await _servicioSunatConsultas.ConsultarConstanciaDeRecepcion(new DatosDocumento
                {
                    RucEmisor = request.Ruc,
                    TipoComprobante = request.TipoDocumento,
                    Serie = request.Serie,
                    Numero = request.Numero
                });

                if (!resultado.Exito)
                {
                    response.Exito = false;
                    response.MensajeRespuesta = resultado.MensajeError;
                }
                else
                    response = await _serializador.GenerarDocumentoRespuesta(resultado.ConstanciaDeRecepcion);
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// Envia el Documento a SUNAT/OSE
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(EnviarDocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<EnviarDocumentoResponse> EnviarDocumento([FromBody] EnviarDocumentoRequest request)
        {
            var response = new EnviarDocumentoResponse();
            var nombreArchivo = $"{request.Ruc}-{request.TipoDocumento}-{request.IdDocumento}";
            var tramaZip = await _serializador.GenerarZip(request.TramaXmlFirmado, nombreArchivo);

            _servicioSunatDocumentos.Inicializar(new ParametrosConexion
            {
                Ruc = request.Ruc,
                UserName = request.UsuarioSol,
                Password = request.ClaveSol,
                EndPointUrl = request.EndPointUrl
            });

            var resultado = await _servicioSunatDocumentos.EnviarDocumento(new DocumentoSunat
            {
                TramaXml = tramaZip,
                NombreArchivo = $"{nombreArchivo}.zip"
            });

            if (!resultado.Exito)
            {
                response.Exito = false;
                response.MensajeError = resultado.MensajeError;
            }
            else
            {
                response = await _serializador.GenerarDocumentoRespuesta(resultado.ConstanciaDeRecepcion);
                // Quitamos la R y la extensión devueltas por el Servicio.
                response.NombreArchivo = nombreArchivo;


            }

            return response;
        }

        /// <summary>
        /// Envia el Resumen Diario/Comunicacion de Baja a SUNAT
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(EnviarResumenResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> EnviarResumen([FromBody]EnviarDocumentoRequest request)
        {
            var response = new EnviarResumenResponse();
            var nombreArchivo = $"{request.Ruc}-{request.IdDocumento}";

            try
            {
                var tramaZip = await _serializador.GenerarZip(request.TramaXmlFirmado, nombreArchivo);

                _servicioSunatDocumentos.Inicializar(new ParametrosConexion
                {
                    Ruc = request.Ruc,
                    UserName = request.UsuarioSol,
                    Password = request.ClaveSol,
                    EndPointUrl = request.EndPointUrl
                });

                var resultado = await _servicioSunatDocumentos.EnviarResumen(new DocumentoSunat
                {
                    NombreArchivo = $"{nombreArchivo}.zip",
                    TramaXml = tramaZip
                });
                
                if (resultado.Exito)
                {
                    response.NroTicket = resultado.NumeroTicket;
                    response.Exito = true;
                    response.NombreArchivo = nombreArchivo;
                }
                else
                {
                    response.MensajeError = resultado.MensajeError;
                    response.Exito = false;
                }
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }
            
            return Ok(response);
        }

        /// <summary>
        /// Firma el Documento XML con el Certificado Digital.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(FirmadoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IActionResult> Firmar([FromBody] FirmadoRequest request)
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
