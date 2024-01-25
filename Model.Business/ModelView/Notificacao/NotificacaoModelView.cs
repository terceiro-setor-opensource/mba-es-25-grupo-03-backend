namespace Business.Model
{
    public class NotificacaoModelView
    {
        public long Id { get; set; }

        public string Instrutor { get; set; } = string.Empty;

        public string Titulo { get; set; } = string.Empty;

        public string Notificacao { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = new DateTime();

        public bool Lida { get; set; }
    }
}
