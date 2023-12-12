namespace Business.Model
{
    public class LoginResponseModelView
    {
        public bool Authenticated { get; set; }

        public DateTime Created { get; set; }

        public DateTime Expiration { get; set; }

        public string AccessToken { get; set; } = string.Empty;
    }
}
