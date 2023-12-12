using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

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

        public static string GetRootConfiguration(string key)
        {
            try
            {
                return _root?.GetSection($"{key}")?.Value!;
            }
            catch
            {
                throw;
            }
        }

        public static bool VerifyHash(string input, string hash)
        {
            string hash2 = GetHash(input);
            return StringComparer.OrdinalIgnoreCase.Compare(hash2, hash) == 0;
        }

        public static string GetHash(string input)
        {
            var array = SHA256.HashData(Encoding.UTF8.GetBytes(input));

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}