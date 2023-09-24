using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MojammatApi.Dto.Users;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace MojammatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }



        [HttpPost("sendOtp", Name = "SendOtpCode")]
       
        public IActionResult SendOtpCode([FromForm] string to)
        {
            try
            {
                TwilioClient.Init("ACee759dd9162be8fa992986e8241201d3", "a4fb81a4e2bc904f2c29228ca66f8b7a");


                var verification = VerificationResource.Create(
                    to: to,
                    channel: "sms",
                    pathServiceSid: "VAc54ac6e8b8e541da66e995e4b7f4b834"
                );
                return Ok(verification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("verifyOtp", Name = "VerifyOtpCode")]

        public IActionResult VerifyOtpCode([FromForm] string to, [FromForm] string code)
        {
            try
            {
                TwilioClient.Init("ACee759dd9162be8fa992986e8241201d3", "a4fb81a4e2bc904f2c29228ca66f8b7a");


                var verificationCheck = VerificationCheckResource.Create(
           to: to,
           code: code,
           pathServiceSid: "VAc54ac6e8b8e541da66e995e4b7f4b834"
       );

                return Ok(verificationCheck);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]

        public IActionResult GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize =25 )
        {
            var users = mapper.Map<List<GetUserDto>>(userRepository.GetUsers(page, pageSize));

            return Ok(users);
        }


        [HttpGet("{id:Guid}", Name = "GetUserById")]
        public IActionResult GetUsersById( Guid id)
        {
            var user = mapper.Map<GetUserDto>(userRepository.GetUser(id));

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUsers([FromForm] CreateUserDto createUserDto)
        {

        
            var users = mapper.Map<Users>(createUserDto);

            userRepository.CreateUser(users);

            return Ok("created seccessfuly");
        }


        [HttpPut( Name = "updateUsers")]
        public IActionResult UpdateUsers(UpdateUserDto updateUserDto)
        {

            var user = mapper.Map<Users>(updateUserDto);
            userRepository.UpdateUser(user);
            return Ok(user);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:Guid}", Name = "DeleteUser")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = userRepository.DeleteUser(id);
            Console.WriteLine(user);

            return Ok();
        }
    }
}