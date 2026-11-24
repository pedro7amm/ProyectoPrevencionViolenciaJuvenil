using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("UsuarioCentroEducativo")]
    public class UsuarioCentroEducativo
    {
        [Key]
        [Column("idUsuarioCentroEducativo")]
        public int IdUsuarioCentroEducativo { get; set; }

        [Column("estudianteActivo")]
        public bool EstudianteActivo { get; set; }

        [Column("Usuario_idUsuario")]
        public int IdUsuario { get; set; }

        public Usuario? Usuario { get; set; }

        [Column("CentroEducativo_idCentroEducativo")]
        public int IdCentroEducativo { get; set; }

        public CentroEducativo? CentroEducativo { get; set; }
    }
}