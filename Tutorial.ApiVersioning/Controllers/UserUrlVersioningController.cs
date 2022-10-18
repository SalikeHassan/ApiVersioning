using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial.ApiVersioning.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/user")]
    [ApiController]
    public class UserUrlVersioningV1Controller : ControllerBase
    {
        private readonly IList<User> users;
        public UserUrlVersioningV1Controller()
        {
            users = new List<User>();
            users.Add(new User() { Id = 1, FullName = "Test1 User", Gender = "Male", IsActive = true });
            users.Add(new User() { Id = 2, FullName = "Test2 User", Gender = "Female", IsActive = true });
            users.Add(new User() { Id = 3, FullName = "Test3 User", Gender = "Female", IsActive = true });
            users.Add(new User() { Id = 4, FullName = "Test4 User", Gender = "Male", IsActive = true });
            users.Add(new User() { Id = 5, FullName = "Test5 User", Gender = "Female", IsActive = false });
            users.Add(new User() { Id = 6, FullName = "Test5 User", Gender = "Male", IsActive = false });
        }

        [HttpGet("getusers")]
        public IActionResult GetAllUser()
        {
            return this.Ok(users);
        }
    }

    [ApiVersion("2.0")]
    [Route("v{v:apiVersion}/user")]
    [ApiController]
    public class UserUrlVersioningV2Controller : ControllerBase
    {
        private readonly IList<User> users;
        public UserUrlVersioningV2Controller()
        {
            users = new List<User>();
            users.Add(new User() { Id = 1, FullName = "Test1 User", Gender = "Male", IsActive = true });
            users.Add(new User() { Id = 2, FullName = "Test2 User", Gender = "Female", IsActive = true });
            users.Add(new User() { Id = 3, FullName = "Test3 User", Gender = "Female", IsActive = true });
            users.Add(new User() { Id = 4, FullName = "Test4 User", Gender = "Male", IsActive = true });
            users.Add(new User() { Id = 5, FullName = "Test5 User", Gender = "Female", IsActive = false });
            users.Add(new User() { Id = 6, FullName = "Test5 User", Gender = "Male", IsActive = false });
        }

        [HttpGet("getusers")]
        public IActionResult GetAllUser()
        {
            return this.Ok(users.Where(x => x.IsActive).ToList());
        }
    }
}
