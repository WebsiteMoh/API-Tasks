using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Product.Data.Data.Identity;
using Product.Services.User;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _context;
        private readonly UserManager<UserDTO> userManager1;

        public UserController(IUserServices context,UserManager<UserDTO> userManager)
        {
            _context = context;
            userManager1=   userManager;
        }
        [HttpPost]
        public async Task<UserDTO> Login(LoginDTO userDTO)
        {
            var user=await _context.Login(userDTO);
            return user;
            
        }
        [HttpPost]
        public async Task<UserDTO> Regester(RejesterDTO userDTO)
        {
            var user = await _context.Register(userDTO);
            return user;

        }
        
        public async Task<UserDTO> GetCurrentUserDetials()
        {
            var UserID = User.FindFirst("UserId");
            var user = await userManager1.FindByIdAsync(UserID.Value);
            return new UserDTO()
            {
                ID = user.ID,
                DisplayName = user.DisplayName,
                Email = user.Email,

            };
        }
    }
}
