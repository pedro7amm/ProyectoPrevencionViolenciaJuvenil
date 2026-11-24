using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Seguimiento")]
    public class Seguimiento
    {
        [Key]
        [Column("idSeguimiento")]
        public int IdSeguimiento { get; set; }

        [Required(ErrorMessage = "El campo asunto del seguimiento es requerido")]
        [MaxLength(45)]
        [Column("asunto_seguimiento")]
        public string Asunto_Seguimiento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo descripción del seguimiento es requerido")]
        [MaxLength(255)]
        [Column("descripcion_seguimiento")]
        public string Descripcion_Seguimiento { get; set; } = string.Empty;

        [Column("fecha_seguimiento")]
        public DateTime Fecha_Seguimiento { get; set; }

        [Column("encargadoSeguimiento_idUsuario")]
        public int IdEncargado { get; set; }

        public Usuario? Encargado { get; set; }

        [Column("estudianteSeguimiento_idUsuario")]
        public int IdEstudiante { get; set; }

        public Usuario? Estudiante { get; set; }
    }
}