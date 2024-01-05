using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("CONTEUDO_CURSO")]
    public class ConteudoCurso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CONTEUDO_CURSO")]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        [Column("DS_CONTEUDO_CURSO")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Column("NU_CONTEUDO_CURSO")]
        public int NumeroOrdem { get; set; }

        [Required]
        [Column("ID_CURSO")]
        public long IdCurso { get; set; }

        [MaxLength(1000)]
        [Column("DS_INFO_CONTEUDO_CURSO")]
        public string Informacoes { get; set; } = string.Empty;

        [Required]
        [Column("DS_URL_VIDEO")]
        public int UrlVideo { get; set; }

        [Column("ID_PRE_REQUISITO")]
        public int? IdPreRequisito { get; set; }

        [Column("IN_PRE_REQUISITO_OBG")]
        public short PreRequisitoObrigatorio { get; set; }

        [Column("IMG_AVATAR")]
        public byte[]? Avatar { get; set; }
    }
}