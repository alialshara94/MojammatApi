using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MojammatApi.Dto.Users;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration configuration;

        public UsersController(IUserRepository userRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
            this.configuration = configuration;
        }



        [HttpPost("sendOtp", Name = "SendOtpCode")]
       
        public IActionResult SendOtpCode([FromForm] string to)
        {
            try
            {
                //TwilioClient.Init("ACee759dd9162be8fa992986e8241201d3", "a4fb81a4e2bc904f2c29228ca66f8b7a");


                //var verification = VerificationResource.Create(
                //    to: to,
                //    channel: "sms",
                //    pathServiceSid: "VAc54ac6e8b8e541da66e995e4b7f4b834"
                //);
                return Ok(to);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost("verifyOtp", Name = "VerifyOtpCode")]

        public IActionResult VerifyOtpCode([FromForm] string to, [FromForm] string code)
        {
            try
            {
       //         TwilioClient.Init("ACee759dd9162be8fa992986e8241201d3", "a4fb81a4e2bc904f2c29228ca66f8b7a");


       //         var verificationCheck = VerificationCheckResource.Create(
       //    to: to,
       //    code: code,
       //    pathServiceSid: "VAc54ac6e8b8e541da66e995e4b7f4b834"
       //);

                //if (true)
                //{


                    (bool status, Users user) res = userRepository.CheckUserIsExsit(to);
                    if (res.status)
                    {
                        var user_token = GenerateAccessToke(res.user);
                        return Ok(new
                        {
                            user = res.user,
                            user_token = user_token,
                            status = true,
                            message = "login successfully"
                        });

                    }
                    else
                    {
                        return Ok(new
                        {

                            status = false,
                            message = "register required"
                        });
                    }

                //}else
                //{
                //    return BadRequest();
                //}


                }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //[Authorize(Roles ="Admin")]
        [HttpGet]

        public IActionResult GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize =25 )
        {
            var users = mapper.Map<List<GetUserDto>>(userRepository.GetUsers(page, pageSize));

            return Ok(users);
        }

        //[Authorize]
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
        public async Task<IActionResult> CreateUsers([FromForm] CreateUserDto createUserDto)
        {
            try
            {

                (bool status, Users user) res = userRepository.CheckUserIsExsit(createUserDto.phone);
                if (res.status)
                {
                    return BadRequest("Phone Number Already Exist");
                }

                //TODO: validate image size and type 

                string folderPath = GetFolderPath();
                string BaseURL = GetBaseURL();
                Guid fileName = Guid.NewGuid();

                if (createUserDto.image != null)
                {
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);

                    }
                    string filePath = folderPath + $"{fileName}{Path.GetExtension(createUserDto.image.FileName)}";
                    using (FileStream fileStream = System.IO.File.Create(filePath))
                    {
                        await createUserDto.image.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    return BadRequest("image is required");
                }

                



                Users user = new Users()
                {
                    fullname = createUserDto.fullname,
                    phone = createUserDto.phone,
                    apartmentNo = createUserDto.apartmentNo!,
                    identification = createUserDto.identification!,
                    building = createUserDto.building!,
                    floor = createUserDto.floor!,
                    role = createUserDto.role,
                    status = createUserDto.status ,
                    avatar = createUserDto.image == null ? "default.png" :  fileName + Path.GetExtension(createUserDto.image.FileName)
                };

                //var users = mapper.Map<Users>(createUserDto);
                
                userRepository.CreateUser(user);
                var user_token = GenerateAccessToke(user);
                return Ok(new
                {
                    user = user,
                    user_token = user_token,
                    status = true,
                    message = "create user successfully"
                });

                //return Ok(new
                //{
                //    FileName = fileName + Path.GetExtension(createUserDto.image.FileName),
                //    FilePath = filePath,
                //    FileURL = BaseURL + fileName + Path.GetExtension(createUserDto.image.FileName)
                //});
            }
            catch
            {
                return BadRequest("Something Went Wrong");
            }

           
        }

        //[Authorize]
        [HttpPut( Name = "updateUsers")]
        public IActionResult UpdateUsers([FromBody] UpdateUserDto updateUserDto, [FromQuery, Required] Guid userId)
        {
            var res = userRepository.UpdateUser(updateUserDto, userId);
            if (res)
            {
                return Ok("updated Successfully");
            } else {
                return NotFound("The User is Not Found");
            }
        }

        //[Authorize(Roles = "Admin")]
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


        [NonAction]
        private string GetFolderPath()
        {
            return webHostEnvironment.WebRootPath + "/Upload/Files/";
        }

        [NonAction]
        private string GetBaseURL()
        {
            return $"{Request.Scheme}://{Request.Host}{Request.PathBase}/Upload/Files/";
        }

        [NonAction]
        private string GenerateAccessToke(Users user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.MobilePhone, user.phone),
                new Claim(ClaimTypes.Role, user.role.ToString())
            };
            //expierAt = DateTime.Now.AddHours(8);
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["jwtKey"]!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}