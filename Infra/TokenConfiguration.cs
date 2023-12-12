using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infra
{
    public static class TokenConfigurations
    {
        public static SecurityKey Key { get; private set; }
        public static SigningCredentials SigningCredentials { get; private set; }

        public static void BuidCredentials()
        {
            Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Utils.GetRootConfiguration("TokenKey")));
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
