using Microsoft.AspNetCore.Identity;
using Product.Data.Data.Identity;
using Product.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Product.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly SignInManager<AppUser> _SignInManager;
        private readonly UserManager<AppUser> _UserManager;
        private readonly ITokenService _TokenServices;


        public UserServices(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,ITokenService TokenServices)
        {
            _SignInManager = signInManager;
            _UserManager = userManager;
            _TokenServices = TokenServices;
        }

        public async Task<UserDTO> Login(LoginDTO userDTO)
        {
            var user=await _UserManager.FindByEmailAsync(userDTO.Email);
            if(user == null)
            {
                return null;
            }
            var result = await _SignInManager.CheckPasswordSignInAsync(user, userDTO.Password, false);

            return new UserDTO()
            {
                ID = Guid.Parse(user.Id),
                DisplayName = user.Name,
                Email = user.Email,
                Token = _TokenServices.GenerateToken(user)

            };
        }

        public async Task<UserDTO> Register(RejesterDTO userDTO)
        {
            var user = await _UserManager.FindByEmailAsync(userDTO.Email);
            if (user is not null)
            {
                return null;
            }
            var appUser = new AppUser
            {
               Name=userDTO.Name, Email=userDTO.Email,
               UserName=userDTO.Name,
            };
            var result=await _UserManager.CreateAsync(appUser,userDTO.Password);
            return new UserDTO()
            {
                ID = Guid.Parse(appUser.Id),
                DisplayName = appUser.Name,
                Email = appUser.Email,
                Token = _TokenServices.GenerateToken(appUser)

            };
            
        }
    }
}
