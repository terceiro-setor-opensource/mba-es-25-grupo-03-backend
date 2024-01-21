using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("MATRICULA_CURSO")]
    public class MatriculaCurso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_MATRICULA_CURSO")]
        public long Id { get; set; }

        [Required]
        [Column("ID_USUARIO")]
        public long IdUsuario { get; set; }

        [Required]
        [Column("ID_CURSO")]
        public long IdCurso { get; set; }


        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; } = new Usuario();

        [ForeignKey("IdCurso")]
        public virtual Curso Curso { get; set; } = new Curso();
    }
}
