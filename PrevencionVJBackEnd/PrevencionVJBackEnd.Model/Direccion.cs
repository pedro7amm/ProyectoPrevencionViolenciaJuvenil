using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Direccion")]
    public class Direccion
    {
        [Key]
        [Column("idDireccion")]
        public int IdDireccion { get; set; }

        [Required(ErrorMessage = "El campo otras señas es requerido")]
        [MaxLength(100)]
        [Column("otras_sennas")]
        public string Otras_Sennas { get; set; } = string.Empty;

        [Column("activo")]
        public bool Activo { get; set; }

        [Column("tipoDireccion_idcatalogo")]
        public int IdTipoDireccion { get; set; }

        public Catalogo? TipoDireccion { get; set; }

        [Column("Distrito_idDistrito1")]
        public int IdDistrito { get; set; }

        public Distrito? Distrito { get; set; }

        public ICollection<Comunidad>? Comunidades { get; set; }

        public ICollection<Actividad>? Actividades { get; set; }

        public ICollection<CentroEducativo>? CentrosEducativos { get; set; }
    }
}