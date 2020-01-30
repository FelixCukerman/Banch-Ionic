using BookStore.BLL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.BLL.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        public const string Issuer = "https://localhost:44367/";
        public const string Audience = "https://localhost:44367/";
        public const int Lifetime = 120;

        private const string _key = "29061eea-b5b2-40fd-8f5f-f2c8584accbd";

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            var keyByteArray = Encoding.ASCII.GetBytes(_key);
            var result = new SymmetricSecurityKey(keyByteArray);

            return result;
        }
    }
}
