using OpenInvoicePeru.Comun.Constantes;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace OpenInvoicePeru.Servicio.Soap
{
    public class ServicioSunatConsultas : IServicioSunatConsultas
    {
        private ConsultasSunat.billServiceClient _proxySunatConsultas;

        private Binding CreateBinding()
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

            _proxySunatConsultas = new ConsultasSunat.billServiceClient(CreateBinding(), new EndpointAddress(parametros.EndPointUrl))
            {
                ClientCredentials =
                {
                    UserName =
                    {
                        UserName = $"{parametros.Ruc}{parametros.UserName}",
                        Password = parametros.Password
                    }
                }
            };
        }

        public async Task<RespuestaSincrono> ConsultarConstanciaDeRecepcion(DatosDocumento request)
        {
            var response = new RespuestaSincrono();

            try
            {
                await _proxySunatConsultas.OpenAsync();

                var resultado = _proxySunatConsultas.getStatusCdr(
                    request.RucEmisor,
                    request.TipoComprobante,
                    request.Serie,
                    Convert.ToInt32(request.Numero)
                );

                await _proxySunatConsultas.CloseAsync();

                if (resultado.content != null)
                    response.ConstanciaDeRecepcion = Convert.ToBase64String(resultado.content);

                response.Exito = resultado.statusCode != "98";

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