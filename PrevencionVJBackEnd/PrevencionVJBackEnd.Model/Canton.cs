using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Canton")]
    public class Canton
    {
        [Key]
        [Column("idCanton")]
        public int IdCanton { get; set; }

        [Required(ErrorMessage = "El campo descripción del cantón es requerido")]
        [MaxLength(45)]
        [Column("descripcion_canton")]
        public string Descripcion_Canton { get; set; } = string.Empty;

        [Column("activo")]
        public bool Activo { get; set; }

        [Column("Provincia_idProvincia")]
        public int IdProvincia { get; set; }

        public Provincia? Provincia { get; set; }

        public ICollection<Distrito>? Distritos { get; set; }
    }
}