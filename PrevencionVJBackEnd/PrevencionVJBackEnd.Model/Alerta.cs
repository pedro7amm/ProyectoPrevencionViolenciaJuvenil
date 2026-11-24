using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Alerta")]
    public class Alerta
    {
        [Key]
        [Column("idAlerta")]
        public int IdAlerta { get; set; }

        [Required(ErrorMessage = "El campo asunto de la alerta es requerido")]
        [MaxLength(45)]
        [Column("asunto_alerta")]
        public string Asunto_Alerta { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo descripción de la alerta es requerido")]
        [MaxLength(120)]
        [Column("descripcion_alerta")]
        public string Descripcion_Alerta { get; set; } = string.Empty;

        [Column("fecha_alerta")]
        public DateTime Fecha_Alerta { get; set; }

        [Column("estudiante_idUsuario")]
        public int IdEstudiante { get; set; }

        public Usuario? Estudiante { get; set; }

        [Column("encargadoCreacionAlerta_idUsuario1")]
        public int IdEncargadoCreacion { get; set; }

        public Usuario? EncargadoCreacion { get; set; }

        [Column("catalogoTipoAlerta_idcatalogo")]
        public int IdTipoAlerta { get; set; }

        public Catalogo? TipoAlerta { get; set; }

        [Column("catalogoEstadoAlerta_idcatalogo")]
        public int IdEstadoAlerta { get; set; }

        public Catalogo? EstadoAlerta { get; set; }
    }
}