using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MojammatApi.Models;
using MojammatApi.Models.Dto;
using MojammatApi.Services;

namespace MojammatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;
        public UsersController(AppDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = context.users.ToList();
            return Ok(users);
        }


        [HttpGet("{id:Guid}", Name = "GetUserById")]
        public IActionResult GetUsersById(Guid id)
        {
            var user = context.users.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUsers( UsersDto usersDto)
        {
            Users user = new Users()
            {
                Fullname = usersDto.Fullname,
                Phone = usersDto.Phone,
                ApartmentNo = usersDto.ApartmentNo ?? "",
                Identification = usersDto.Identification ?? "",
                Building = usersDto.Building ?? "",
                Floor = usersDto.Floor ?? "",
                Role = "User",
                Avatar = usersDto.Avatar ?? ""

            };

            context.users.Add(user);
            context.SaveChanges();
            return Ok(user);
        }


        [HttpPut("{id:Guid}", Name = "updateUsers")]
        public IActionResult UpdateUsers(Guid id , UsersDto usersDto)
        {

            var user = context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            //Users user = new Users()
            //{
            user.Fullname = usersDto.Fullname;
            user.Phone = usersDto.Phone;
            user.ApartmentNo = usersDto.ApartmentNo ?? "";
            user.Identification = usersDto.Identification ?? "";
            user.Building = usersDto.Building ?? "";
            user.Floor = usersDto.Floor ?? "";
            user.Role = "User";
            user.Avatar = usersDto.Avatar ?? "";

            //};

            //context.users.Add(user);
            context.SaveChanges();
            return Ok(user);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:Guid}", Name = "DeleteUser")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            context.users.Remove(user);
            context.SaveChanges();

            return Ok();
        }
    }
}