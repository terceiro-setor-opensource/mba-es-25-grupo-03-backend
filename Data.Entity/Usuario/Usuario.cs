using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_USUARIO")]
        public long Id { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("NM_USUARIO")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(14)]
        [Column("NU_DOCUMENTO")]
        public string Documento { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        [Column("DS_SENHA")]
        public string Senha { get; set; } = string.Empty;

        [Required]
        [MaxLength(64)]
        [Column("DS_EMAIL")]
        public string Email { get; set; } = string.Empty;

        [Column("IMG_AVATAR")]
        public byte[]? Avatar { get; set; }
    }
}