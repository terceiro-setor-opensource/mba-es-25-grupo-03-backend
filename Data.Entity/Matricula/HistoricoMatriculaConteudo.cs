using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("HISTORICO_MATRICULA_CONTEUDO")]
    public class HistoricoMatriculaConteudo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_HISTORICO_MATRICULA_CONTEUDO")]
        public long Id { get; set; }

        [Required]
        [Column("ID_MATRICULA_CURSO")]
        public long IdMatriculaCurso { get; set; }

        [Required]
        [Column("ID_CONTEUDO_CURSO")]
        public long IdConteudoCurso { get; set; }

        [Column("DT_FINALIZACAO")]
        public DateTime? DataFinalizacao { get; set; }


        [ForeignKey("IdConteudoCurso")]
        public virtual List<ConteudoCurso>? ConteudoCurso { get; set; } = new List<ConteudoCurso>();
    }
}
