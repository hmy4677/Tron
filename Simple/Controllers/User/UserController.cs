using Furion.DataEncryption;
using Interface.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;

namespace Simple.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<dynamic> Login([FromBody] LoginInput input)
        {
            var user = await _service.UserLogin(input);
            var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>()
              {
                {"UserId",user.Id },
                {"Account",user.Account },
              });
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken);
            _httpContextAccessor.HttpContext.Response.Headers["access-token"] = accessToken;
            _httpContextAccessor.HttpContext.Response.Headers["x-access-token"] = refreshToken;
            return user;
        }

        [HttpDelete("{id}")]
        public bool Del(long id)
        {
            return _service.DeleteUser(id);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<bool> AddNewUser([FromBody] UserAddInput input)
        {
            return await _service.AddUser(input);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<int> UpdateUser(long id, [FromBody] UserInfo info)
        {
            return await _service.UpdateUser(id, info);
        }
    }
}