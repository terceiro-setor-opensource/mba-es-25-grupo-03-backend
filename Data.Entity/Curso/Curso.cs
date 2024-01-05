using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("CURSO")]
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CURSO")]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        [Column("DS_CURSO")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Column("ID_USUARIO")]
        public long IdUsuario { get; set; }

        [Required]
        [Column("ID_CATEGORIA_CURSO")]
        public long IdCategoriaCurso { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column("DS_INFO_CURSO")]
        public string Informacoes { get; set; } = string.Empty;

        [Column("ID_PRE_REQUISITO")]
        public int? IdPreRequisito { get; set; }

        [Column("IN_PRE_REQUISITO_OBG")]
        public short PreRequisitoObrigatorio { get; set; }

        [Column("IMG_AVATAR")]
        public byte[]? Avatar { get; set; }
    }
}