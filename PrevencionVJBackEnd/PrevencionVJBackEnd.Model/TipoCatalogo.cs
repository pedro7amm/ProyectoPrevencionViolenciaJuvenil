using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("tipoCatalogo")]
    public class TipoCatalogo
    {
        [Key]
        [Column("idtipoCatalogo")]
        public int IdTipoCatalogo { get; set; }

        [Required(ErrorMessage = "El campo nombre del catálogo es requerido")]
        [MaxLength(45)]
        [Column("nombre_catalogo")]
        public string Nombre_Catalogo { get; set; } = string.Empty;

        [Column("activo")]
        public bool Activo { get; set; }

        public ICollection<Catalogo>? Catalogos { get; set; }
    }
}