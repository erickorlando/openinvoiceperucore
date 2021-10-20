using System.Threading.Tasks;

namespace OpenInvoicePeru.Servicio
{
    public interface IServicioSunatDocumentos : IServicioSunat
    {
        Task<RespuestaSincrono> EnviarDocumento(DocumentoSunat request);
        Task<RespuestaAsincrono> EnviarResumen(DocumentoSunat request);
        Task<RespuestaSincrono> ConsultarTicket(string numeroTicket);
    }
}