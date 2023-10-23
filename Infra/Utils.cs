using Microsoft.Extensions.Configuration;

namespace Infra
{
    public static class Utils
    {
        private static readonly IConfiguration? _root;
        private static readonly ConfigurationBuilder? _configurationBuilder;

        static Utils()
        {
            if (_configurationBuilder == null)
            {
                _configurationBuilder = new ConfigurationBuilder();
                _configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
                _configurationBuilder.AddJsonFile("appsettings.json", optional: true);

                _root ??= _configurationBuilder.Build();
            }
        }

        public static string? GetConnectionString(string key)
        {
            try
            {
                return _root?.GetSection($"ConnectionStrings:{key}")?.Value;
            }
            catch
            {
                throw;
            }
        }
    }
}