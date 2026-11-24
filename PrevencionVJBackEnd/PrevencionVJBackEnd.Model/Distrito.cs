using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Distrito")]
    public class Distrito
    {
        [Key]
        [Column("idDistrito")]
        public int IdDistrito { get; set; }

        [Required(ErrorMessage = "El campo descripción del distrito es requerido")]
        [MaxLength(45)]
        [Column("descripcion_distrito")]
        public string Descripcion_Distrito { get; set; } = string.Empty;

        [Column("activo")]
        public bool Activo { get; set; }

        [Required(ErrorMessage = "El campo código postal es requerido")]
        [MaxLength(12)]
        [Column("codigo_postal")]
        public string Codigo_Postal { get; set; } = string.Empty;

        [Column("Canton_idCanton")]
        public int IdCanton { get; set; }

        public Canton? Canton { get; set; }

        public ICollection<Direccion>? Direcciones { get; set; }
    }
}