using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Comunidad")]
    public class Comunidad
    {
        [Key]
        [Column("idComunidad")]
        public int IdComunidad { get; set; }

        [Required(ErrorMessage = "El campo nombre de la comunidad es requerido")]
        [MaxLength(45)]
        [Column("nombre_comunidad")]
        public string Nombre_Comunidad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo descripción de la comunidad es requerido")]
        [MaxLength(45)]
        [Column("descripcion_comunidad")]
        public string Descripcion_Comunidad { get; set; } = string.Empty;

        [Column("Direccion_comunidad_idDireccion")]
        public int IdDireccion { get; set; }

        public Direccion? Direccion { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }

        public ICollection<Actividad>? Actividades { get; set; }
    }
}