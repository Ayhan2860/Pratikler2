using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.DbOperations;
using WebApi.TokenOperations.Models;
using WebApi.UserOperations.Commands.CreateUser;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController:ControllerBase
    {
        private readonly  IBookStoreDbContext _context;
       
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Register([FromBody] CreateUserModel register)
        {
            CreateUserCommand command = new CreateUserCommand(_context,_mapper);
            command.Model = register;
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Kaydınız Oluşturuldu");

        }

        [HttpPost("connect/token")]
        public ActionResult<Token> Login([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            CreateTokenCommandValidator validator = new CreateTokenCommandValidator();
            command.Model = login;
            validator.ValidateAndThrow(command);
            var token = command.Handle();
            return token;
        }
    }
}    