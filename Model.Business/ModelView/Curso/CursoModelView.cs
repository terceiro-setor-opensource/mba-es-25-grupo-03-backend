using Microsoft.AspNetCore.Http;

namespace Business.Model.ModelView
{
    public class CursoModelView
    {
        public long Id { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public UsuarioModelView Usuario { get; set; } = new UsuarioModelView();

        public CategoriaCursoModelView Categoria { get; set; } = new CategoriaCursoModelView();

        public string Informacoes { get; set; } = string.Empty;

        public bool Obrigatorio { get; set; }

        public int DuracaoMinutos { get; set; }

        public string DuracaoFormatada { get; set; } = string.Empty;

        public double Classificacao { get; set; }

        public DateTime DataCriacao { get; set; }

        public string? Avatar { get; set; }
    }
}
