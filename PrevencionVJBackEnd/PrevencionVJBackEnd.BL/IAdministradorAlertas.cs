using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorAlertas
    {
        Task<Alerta?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Alerta>> ObtenerAsync();
        Task<IEnumerable<Alerta>> ObtenerPorEstudianteAsync(int idEstudiante);
        Task<IEnumerable<Alerta>> ObtenerPorEstadoAsync(int idEstadoAlerta);
        Task AgregarAsync(Alerta alerta);
        Task EditarAsync(Alerta alerta);
    }
}
