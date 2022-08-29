using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using userAPI.Data;
using userAPI.Model;

namespace userAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserDbContext _userDbContext;
        public UserController(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        [HttpGet]
        public async Task <IActionResult> GetAllUsers()
        {
            var users = await _userDbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]Userss userReq)
        {
            userReq.Id = Guid.NewGuid();
            await _userDbContext.Users.AddAsync(userReq);
            await _userDbContext.SaveChangesAsync();

            return Ok(userReq);
        }
    }
}
