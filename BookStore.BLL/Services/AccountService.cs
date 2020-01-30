using BookStore.BLL.Helpers;
using BookStore.BLL.Interfaces;
using BookStore.EL.Entities;
using BookStore.Shared.Enums;
using BookStore.Shared.Resources;
using BookStore.ViewModelsLayer.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<User> _userManager;
        private IAuthHelper _authHelper;

        public AccountService(UserManager<User> userManager, IAuthHelper authHelper)
        {
            _authHelper = authHelper;
            _userManager = userManager;
        }

        private async Task<ClaimsIdentity> GetIdentity(LoginViewModel model)
        {
            User user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                throw new NullReferenceException(ApplicationResources.UserNotFoundMessage);
            }

            bool passwordIsValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if(!passwordIsValid)
            {
                throw new Exception(ApplicationResources.PassowrdIsNotValid);
            }

            string userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, ApplicationResources.AuthenticationType,
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        public async Task<GetTokenViewModel> GetToken(LoginViewModel model)
        {
            ClaimsIdentity identity = await GetIdentity(model);

            DateTime currentDate = DateTime.Now;

            var jwt = new JwtSecurityToken
            (
                issuer: AuthHelper.Issuer,
                audience: AuthHelper.Audience,
                notBefore: currentDate,
                claims: identity.Claims,
                expires: currentDate.Add(TimeSpan.FromMinutes(AuthHelper.Lifetime)),
                signingCredentials: new SigningCredentials(_authHelper.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            );

            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new GetTokenViewModel
            {
                AccessToken = encodedJwt,
                Username = identity.Name
            };

            return response;
        }

        public async Task CreateUser(RegisterUserViewModel model)
        {
            var user = new User();
            user.UserName = model.Username;

            await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, UserRoleType.User.ToString());
        }
    }
}
