using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("catalogo")]
    public class Catalogo
    {
        [Key]
        [Column("idcatalogo")]
        public int IdCatalogo { get; set; }

        [Required(ErrorMessage = "El campo descripción del catálogo es requerido")]
        [MaxLength(45)]
        [Column("descripcion_catalogo")]
        public string Descripcion_Catalogo { get; set; } = string.Empty;

        [Column("activo")]
        public bool Activo { get; set; }

        [Column("tipoCatalogo_idtipoCatalogo")]
        public int IdTipoCatalogo { get; set; }

        public TipoCatalogo? TipoCatalogo { get; set; }

        public ICollection<Direccion>? DireccionesTipo { get; set; }

        public ICollection<Usuario>? UsuariosGenero { get; set; }

        public ICollection<Usuario>? UsuariosTipo { get; set; }

        public ICollection<Actividad>? ActividadesEstado { get; set; }

        public ICollection<Alerta>? AlertasTipo { get; set; }

        public ICollection<Alerta>? AlertasEstado { get; set; }
    }
}