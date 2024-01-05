using System.Text.Json.Serialization;

namespace Business.Model.ModelView
{
    public class UsuarioModelView
    {
        public long Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Documento { get; set; } = string.Empty;

        [JsonIgnore]
        public string? Senha { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}
