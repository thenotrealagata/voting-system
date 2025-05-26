using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.API.Dto;
using VotingSystem.API.Model.Entities;
using VotingSystem.API.Services;

namespace VotingSystem.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(UserResponseDto))]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDto userRequestDto)
        {
            var user = _mapper.Map<User>(userRequestDto);
            await _userService.AddUserAsync(user, userRequestDto.Password);

            var response = _mapper.Map<UserResponseDto>(user);
            return CreatedAtAction(nameof(CreateUser), new { id = response.Id }, response);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(LoginResponseDto))]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var (authToken, refreshToken, userId) = await _userService.LoginAsync(loginRequestDto.Email, loginRequestDto.Password);
            var response = new LoginResponseDto
            {
                AuthToken = authToken,
                RefreshToken = refreshToken,
                UserId = userId
            };

            return Ok(response);
        }



    }
}
