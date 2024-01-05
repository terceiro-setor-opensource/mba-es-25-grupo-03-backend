using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("CATEGORIA_CURSO")]
    public class CategoriaCurso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CATEGORIA_CURSO")]
        public long Id { get; set; }

        [Required]
        [MaxLength(256)]
        [Column("DS_CATEGORIA_CURSO")]
        public string Nome { get; set; } = string.Empty;

        [Column("IMG_AVATAR")]
        public byte[]? Avatar { get; set; }
    }
}