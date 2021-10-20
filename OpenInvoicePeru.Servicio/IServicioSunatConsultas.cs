using System.Threading.Tasks;

namespace OpenInvoicePeru.Servicio
{
    public interface IServicioSunatConsultas : IServicioSunat
    {
        Task<RespuestaSincrono> ConsultarConstanciaDeRecepcion(DatosDocumento request);
    }
}