using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("NOTIFICACAO_MATRICULA")]
    public class NotificacaoMatricula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_NOTIFICACAO_MATRICULA")]
        public long Id { get; set; }

        [Required]
        [Column("ID_MATRICULA_CURSO")]
        public long IdMatricula { get; set; }

        [Required]
        [Column("ID_NOTIFICACAO_CURSO")]
        public long IdNotificacaoCurso { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime DataCriacao { get; set; }

        [Column("IN_LIDA")]
        public short Lida { get; set; }


        [ForeignKey("IdMatricula")]
        public virtual MatriculaCurso MatriculaCurso { get; set; } = new MatriculaCurso();

        [ForeignKey("IdNotificacaoCurso")]
        public virtual NotificacaoCurso NotificacaoCurso { get; set; } = new NotificacaoCurso();
    }
}
