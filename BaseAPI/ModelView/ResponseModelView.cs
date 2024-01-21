namespace BaseAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class ReponseModelView
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ErroModelView> Erros { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errors"></param>
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

    /// <summary>
    /// 
    /// </summary>
    public class ErroModelView
    {
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// 
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="propertyName"></param>
        public ErroModelView(string error, string propertyName = "")
        {
            ErrorMessage = error;
            PropertyName = propertyName;
        }
    }
}
