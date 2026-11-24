using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.BL
{
    public interface IAdministradorSeguimientos
    {
        Task<Seguimiento?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Seguimiento>> ObtenerAsync();
        Task<IEnumerable<Seguimiento>> ObtenerPorEstudianteAsync(int idEstudiante);
        Task<IEnumerable<Seguimiento>> ObtenerPorEncargadoAsync(int idEncargado);
        Task AgregarAsync(Seguimiento seguimiento);
        Task EditarAsync(Seguimiento seguimiento);
    }
}
