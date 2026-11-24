using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Provincia")]
    public class Provincia
    {
        [Key]
        [Column("idProvincia")]
        public int IdProvincia { get; set; }

        [Required(ErrorMessage = "El campo descripción de la provincia es requerido")]
        [MaxLength(45)]
        [Column("descripcion_provincia")]
        public string Descripcion_Provincia { get; set; } = string.Empty;

        [Column("activo")]
        public bool Activo { get; set; }

        public ICollection<Canton>? Cantones { get; set; }
    }
}