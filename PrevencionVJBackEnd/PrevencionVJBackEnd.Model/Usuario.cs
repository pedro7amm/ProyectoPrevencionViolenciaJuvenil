using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo cédula es requerido")]
        [MaxLength(20)]
        [Column("cedula_usuario")]
        public string Cedula_Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(20)]
        [Column("nombre_usuario")]
        public string Nombre_Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [MaxLength(20)]
        [Column("apellido1_usuario")]
        public string Apellido1_Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El segundo apellido es requerido")]
        [MaxLength(20)]
        [Column("apellido2_usuario")]
        public string Apellido2_Usuario { get; set; } = string.Empty;

        [Column("fecha_nacimiento_usuario")]
        public DateOnly Fecha_Nacimiento_Usuario { get; set; }

        [Column("fecha_registro_usuario")]
        public DateTime Fecha_Registro_Usuario { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        [Column("catalogoGeneroUsuario_idcatalogo")]
        public int IdGenero { get; set; }

        public Catalogo? Genero { get; set; }

        [Column("Comunidad_idComunidad")]
        public int IdComunidad { get; set; }

        public Comunidad? Comunidad { get; set; }

        [Column("catalogoTipoUsuario_idcatalogo")]
        public int IdTipoUsuario { get; set; }

        public Catalogo? TipoUsuario { get; set; }

        public ICollection<Participacion>? Participaciones { get; set; }

        public ICollection<Alerta>? AlertasComoEstudiante { get; set; }

        public ICollection<Alerta>? AlertasCreadas { get; set; }

        public ICollection<Seguimiento>? SeguimientosComoEncargado { get; set; }

        public ICollection<Seguimiento>? SeguimientosComoEstudiante { get; set; }

        public ICollection<UsuarioCentroEducativo>? UsuariosCentrosEducativos { get; set; }
    }
}