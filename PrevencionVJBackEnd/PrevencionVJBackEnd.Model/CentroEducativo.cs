using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("CentroEducativo")]
    public class CentroEducativo
    {
        [Key]
        [Column("idCentroEducativo")]
        public int IdCentroEducativo { get; set; }

        [Required(ErrorMessage = "El campo nombre del centro educativo es requerido")]
        [MaxLength(90)]
        [Column("nombre_centroEducativo")]
        public string Nombre_CentroEducativo { get; set; } = string.Empty;

        [Column("fecha_registro_centroEducativo")]
        public DateTime Fecha_Registro_CentroEducativo { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        [Column("Direccion_idDireccion")]
        public int IdDireccion { get; set; }

        public Direccion? Direccion { get; set; }

        public ICollection<UsuarioCentroEducativo>? UsuariosCentrosEducativos { get; set; }
    }
}