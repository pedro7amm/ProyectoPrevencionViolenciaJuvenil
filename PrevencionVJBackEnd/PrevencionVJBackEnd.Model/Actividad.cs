using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevencionVJBackEnd.Model
{
    [Table("Actividad")]
    public class Actividad
    {
        [Key]
        [Column("idActividad")]
        public int IdActividad { get; set; }

        [Required(ErrorMessage = "El campo nombre de la actividad es requerido")]
        [MaxLength(45)]
        [Column("nombre_actividad")]
        public string Nombre_Actividad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo descripción de la actividad es requerido")]
        [MaxLength(120)]
        [Column("descripcion_actividad")]
        public string Descripcion_Actividad { get; set; } = string.Empty;

        [Column("fecha_inicio_actividad")]
        public DateTime Fecha_Inicio_Actividad { get; set; }

        [Column("fecha_fin_actividad")]
        public DateTime Fecha_Fin_Actividad { get; set; }

        [Column("cupo_maximo_actividad")]
        public int Cupo_Maximo_Actividad { get; set; }

        [Column("Comunidad_idComunidad")]
        public int IdComunidad { get; set; }

        public Comunidad? Comunidad { get; set; }

        [Column("catalogoEstadoActividad_idcatalogo")]
        public int IdEstadoActividad { get; set; }

        public Catalogo? EstadoActividad { get; set; }

        [Column("Direccion_idDireccion")]
        public int IdDireccion { get; set; }

        public Direccion? Direccion { get; set; }

        public ICollection<Participacion>? Participaciones { get; set; }
    }
}