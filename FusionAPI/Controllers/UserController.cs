using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FusionAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAddUserUseCase _addUserUseCase;
        private readonly IGetAllUsersUseCase _getAllUsersUseCase;
        private readonly IGetUserByIdUseCase _getUserByIdUseCase;

        public UserController(IAddUserUseCase addUserUseCase, IGetAllUsersUseCase getAllUsersUseCase, IGetUserByIdUseCase getUserByIdUseCase)
        {
            _addUserUseCase = addUserUseCase;
            _getAllUsersUseCase = getAllUsersUseCase;
            _getUserByIdUseCase = getUserByIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] CreateUserRequest newUser, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User
                {
                    Email = newUser.Email,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    PhoneNumber = newUser.PhoneNumber,
                    ConfirmPassword = BCrypt.Net.BCrypt.HashPassword(newUser.ConfirmPassword),
                    AcceptConditions = newUser.AcceptConditions,
                    Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                };

                var result = await _addUserUseCase.ExecuteAsync(user, cancellationToken);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync(CancellationToken ct)
        {
            try
            {
                var users = await _getAllUsersUseCase.ExecuteAsync(ct);
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id, CancellationToken ct)
        {
            try
            {
                var user = await _getUserByIdUseCase.ExecuteAsync(id, ct);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
