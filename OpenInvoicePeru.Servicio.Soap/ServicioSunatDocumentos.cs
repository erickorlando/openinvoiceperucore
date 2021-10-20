using Documentos;
using OpenInvoicePeru.Comun.Constantes;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace OpenInvoicePeru.Servicio.Soap
{
    public class ServicioSunatDocumentos : IServicioSunatDocumentos
    {
        private Documentos.billServiceClient _proxyDocumentos;

        Binding CreateBinding()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            var elements = binding.CreateBindingElements();
            elements.Find<SecurityBindingElement>().IncludeTimestamp = false;
            return new CustomBinding(elements);
        }

        public void Inicializar(ParametrosConexion parametros)
        {
            System.Net.ServicePointManager.UseNagleAlgorithm = true;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.CheckCertificateRevocationList = true;

            _proxyDocumentos = new billServiceClient(CreateBinding(), new EndpointAddress(parametros.EndPointUrl))
            {
                ClientCredentials =
                {
                    UserName =
                    {
                        UserName = parametros.Ruc + parametros.UserName,
                        Password = parametros.Password
                    }
                }
            };
        }

        public async Task<RespuestaSincrono> EnviarDocumento(DocumentoSunat request)
        {
            var dataOrigen = Convert.FromBase64String(request.TramaXml);
            var response = new RespuestaSincrono();

            try
            {
                await _proxyDocumentos.OpenAsync();
                var resultado = await _proxyDocumentos.sendBillAsync(request.NombreArchivo, dataOrigen, string.Empty);

                await _proxyDocumentos.CloseAsync();

                response.ConstanciaDeRecepcion = Convert.ToBase64String(resultado.applicationResponse);
                response.Exito = true;
            }
            catch (FaultException ex)
            {
                response.MensajeError = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                var msg = string.Concat(ex.InnerException?.Message, ex.Message);
                if (msg.Contains(Formatos.FaultCode))
                {
                    var posicion = msg.IndexOf(Formatos.FaultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + Formatos.FaultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.MensajeError = msg;
            }

            return response;
        }

        public async Task<RespuestaAsincrono> EnviarResumen(DocumentoSunat request)
        {
            var dataOrigen = Convert.FromBase64String(request.TramaXml);
            var response = new RespuestaAsincrono();

            try
            {
                await _proxyDocumentos.OpenAsync();
                var resultado = await _proxyDocumentos.sendSummaryAsync(request.NombreArchivo, dataOrigen, string.Empty);

                await _proxyDocumentos.CloseAsync();

                response.NumeroTicket = resultado.ticket;
                response.Exito = true;
            }
            catch (FaultException ex)
            {
                response.MensajeError = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? string.Concat(ex.InnerException.Message, ex.Message) : ex.Message;
                if (msg.Contains(Formatos.FaultCode))
                {
                    var posicion = msg.IndexOf(Formatos.FaultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + Formatos.FaultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.MensajeError = msg;
            }

            return response;
        }

        public async Task<RespuestaSincrono> ConsultarTicket(string numeroTicket)
        {
            var response = new RespuestaSincrono();

            try
            {
                await _proxyDocumentos.OpenAsync();
                var resultado = await _proxyDocumentos.getStatusAsync(numeroTicket);

                await _proxyDocumentos.CloseAsync();

                response.CodigoRetorno = resultado.status.statusCode;
                if (resultado.status.content != null)
                    response.ConstanciaDeRecepcion = Convert.ToBase64String(resultado.status.content);

                response.Exito = resultado.status.content != null;
                response.MensajeError = resultado.status.statusCode;
            }
            catch (FaultException ex)
            {
                response.MensajeError = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? string.Concat(ex.InnerException.Message, ex.Message) : ex.Message;
                if (msg.Contains(Formatos.FaultCode))
                {
                    var posicion = msg.IndexOf(Formatos.FaultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + Formatos.FaultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.MensajeError = msg;
            }

            return response;
        }

    }
}