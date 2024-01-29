namespace Business.Model.ModelView
{
    public class MatriculaModelView
    {
        public long IdMatricula { get; set; }

        public long IdCurso { get; set; }

        public long IdUsuario { get; set; }

        public string Curso { get; set; } = string.Empty;

        public string NomeInstrutor { get; set; } = string.Empty;
    }
}
