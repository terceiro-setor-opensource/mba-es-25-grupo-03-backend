namespace Business.Model.ModelView
{
    public class MensagemModelView
    {
        public long IdMatricula { get; set; }

        public string Curso { get; set; } = string.Empty;

        public string NomeInstrutor { get; set; } = string.Empty;

        public string Mensagem { get; set; } = string.Empty;

        public DateTime? DataEnvio { get; set; }

        public bool Instrutor { get; set; }

        public bool Lida { get; set; }
    }
}
