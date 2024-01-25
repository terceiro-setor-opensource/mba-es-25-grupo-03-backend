using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("NOTIFICACAO_CURSO")]
    public class NotificacaoCurso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_NOTIFICACAO_CURSO")]
        public long Id { get; set; }

        [Required]
        [Column("ID_CURSO")]
        public long IdCurso { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("DS_TITULO")]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [MaxLength(512)]
        [Column("DS_NOTIFICACAO")]
        public string Notificacao { get; set; } = string.Empty;

        [Column("DT_CRIACAO")]
        public DateTime DataCriacao { get; set; }


        [ForeignKey("IdCurso")]
        public virtual Curso Curso { get; set; } = new Curso();
    }
}
