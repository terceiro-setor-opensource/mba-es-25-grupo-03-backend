namespace Business.Model
{
    public class MatriculaModelView
    {
        public long IdMatricula { get; set; }

        public string Curso { get; set; } = string.Empty;

        public string NomeInstrutor { get; set; } = string.Empty;

        //public int Concluido { get; set; }

        //public int Total { get; set; }
    }
}
