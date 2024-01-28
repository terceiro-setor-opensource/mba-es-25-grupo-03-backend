using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("MENSAGEM")]
    public class Mensagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_MENSAGEM")]
        public long Id { get; set; }

        [Required]
        [Column("ID_MATRICULA_CURSO")]
        public long IdMatriculaCurso { get; set; }

        [Required]
        [MaxLength(256)]
        [Column("DS_MENSAGEM")]
        public string Texto { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DT_ENVIO")]
        public DateTime? DataEnvio { get; set; }

        [Column("IN_INSTRUTOR")]
        public short Instrutor { get; set; }

        [Column("IN_LIDA")]
        public short Lida { get; set; }


        [ForeignKey("IdMatriculaCurso")]
        public virtual MatriculaCurso MatriculaCurso { get; set; } = new MatriculaCurso();
    }
}
