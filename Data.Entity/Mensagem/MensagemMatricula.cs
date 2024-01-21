using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("MENSAGEM_MATRICULA")]
    public class MensagemMatricula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_MENSAGEM_MATRICULA")]
        public long Id { get; set; }

        [Required]
        [Column("ID_MATRICULA_CURSO")]
        public long IdMatricula { get; set; }

        [Required]
        [Column("ID_MENSAGEM_CURSO")]
        public long IdMensagemCurso { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime DataCriacao { get; set; }

        [Column("IN_LIDA")]
        public short Lida { get; set; }


        [ForeignKey("IdMatricula")]
        public virtual MatriculaCurso MatriculaCurso { get; set; } = new MatriculaCurso();

        [ForeignKey("IdMensagemCurso")]
        public virtual MensagemCurso MensagemCurso { get; set; } = new MensagemCurso();
    }
}
