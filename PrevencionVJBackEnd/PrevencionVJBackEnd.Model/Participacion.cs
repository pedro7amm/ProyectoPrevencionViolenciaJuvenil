using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Participacion")]
    public class Participacion
    {
        [Key]
        [Column("idParticipacion")]
        public int IdParticipacion { get; set; }

        [Column("fecha_inscripcion")]
        public DateTime Fecha_Inscripcion { get; set; }

        [Column("asistio")]
        public bool Asistio { get; set; }

        [Column("Usuario_idUsuario")]
        public int IdUsuario { get; set; }

        public Usuario? Usuario { get; set; }

        [Column("Actividad_idActividad")]
        public int IdActividad { get; set; }

        public Actividad? Actividad { get; set; }
    }
}