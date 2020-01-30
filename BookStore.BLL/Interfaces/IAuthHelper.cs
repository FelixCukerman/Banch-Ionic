using Microsoft.IdentityModel.Tokens;

namespace BookStore.BLL.Interfaces
{
    public interface IAuthHelper
    {
        SymmetricSecurityKey GetSymmetricSecurityKey();
    }
}
