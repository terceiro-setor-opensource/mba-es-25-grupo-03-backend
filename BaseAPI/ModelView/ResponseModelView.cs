namespace BaseAPI
{
    public class ReponseModelView
    {
        public List<ErroModelView> Erros { get; }

        public ReponseModelView(params string[] errors)
        {
            Erros = new List<ErroModelView>();

            if (errors != null && errors.Any())
            {
                foreach (var error in errors)
                {
                    Erros.Add(new ErroModelView(error));
                }
            }
        }
    }

    public class ErroModelView
    {
        public string ErrorMessage { get; }

        public string PropertyName { get; }

        public ErroModelView(string error, string propertyName = "")
        {
            ErrorMessage = error;
            PropertyName = propertyName;
        }
    }
}
