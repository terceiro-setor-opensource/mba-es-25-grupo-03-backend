namespace Business.Model
{
    public class MensagemModelView
    {
        public string Instrutor { get; set; } = string.Empty;

        public string Titulo { get; set; } = string.Empty;

        public string Mensagem { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = new DateTime();

        public bool Lida { get; set; }
    }
}
