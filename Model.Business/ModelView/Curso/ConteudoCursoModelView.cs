using System.Text.Json.Serialization;

namespace Business.Model.ModelView
{
    public class ConteudoCursoModelView
    {
        public long Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long IdCurso { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public int Ordem { get; set; }

        public short DuracaoMinutos { get; set; }

        public string DuracaoFormatada { get; set; } = string.Empty;

        public string Informacoes { get; set; } = string.Empty;

        public string UrlVideo { get; set; } = string.Empty;
    }
}
