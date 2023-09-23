using System;
using Microsoft.AspNetCore.Mvc;
using MojammatApi.Models;
using MojammatApi.Services;
using System.Xml.Linq;
using MojammatApi.Dto;

namespace MojammatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
        {
            private readonly AppDbContext context;
            public VisitorController(AppDbContext context)
            {
                this.context = context;
            }


        //    [HttpGet]
        //    public IActionResult GetVisitors()
        //    {
        //        var visitors = context.visitors.ToList();
        //    Console.WriteLine("================");
        //    Console.WriteLine(visitors[0].users);
        //        return Ok(visitors);
        //    }


        //    [HttpGet("{id:Guid}", Name = "GetvisitorById")]
        //    public IActionResult GetvisitorsById(Guid id)
        //    {
        //        var visitor = context.visitors.Find(id);

        //        if (visitor == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(visitor);
        //    }

        //    [HttpPost]
        //    public IActionResult Createvisitors([FromBody]  VisitorDto visitorDto)
        //    {

        //    var user = context.users.Find(visitorDto.userId);
        //    if (user == null)
        //    {
        //        return BadRequest("Invalid User Id");
        //    }

        //    Visitor visitors = new Visitor()
        //        {
        //            VFullname = visitorDto.VFullname,
        //            InDate = visitorDto.InDate,
        //            InTime = visitorDto.InTime ,
        //            OutDate = visitorDto.OutDate ,
        //            OutTime = visitorDto.OutTime,
        //            Status = visitorDto.Status ,

        //            users = user
        //        };

        //        context.visitors.Add(visitors);
        //        context.SaveChanges();
        //        return Ok(visitors);
        //    }


        //    [HttpPut("{id:Guid}", Name = "updatevisitors")]
        //public IActionResult UpdateVisitor(Guid id, [FromBody] VisitorDto visitorDto)
        //{
        //    var existingVisitor = context.visitors.Find(id);

        //    if (existingVisitor == null)
        //    {
        //        return NotFound("Visitor not found");
        //    }

        //    var user = context.users.Find(visitorDto.userId);
        //    if (user == null)
        //    {
        //        return BadRequest("Invalid User Id");
        //    }

        //    // Update the properties of the existing visitor
        //    existingVisitor.VFullname = visitorDto.VFullname;
        //    existingVisitor.InDate = visitorDto.InDate;
        //    existingVisitor.InTime = visitorDto.InTime;
        //    existingVisitor.OutDate = visitorDto.OutDate;
        //    existingVisitor.OutTime = visitorDto.OutTime;
        //    existingVisitor.Status = visitorDto.Status;
        //    existingVisitor.users = user;

        //    context.SaveChanges();

        //    return Ok(existingVisitor);
        //}

        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //    [ProducesResponseType(StatusCodes.Status404NotFound)]
        //    [HttpDelete("{id:Guid}", Name = "Deletevisitors")]
        //public IActionResult DeleteVisitor(Guid id)
        //{
        //    var existingVisitor = context.visitors.Find(id);

        //    if (existingVisitor == null)
        //    {
        //        return NotFound("Visitor not found");
        //    }

        //    context.visitors.Remove(existingVisitor);
        //    context.SaveChanges();

        //    return NoContent(); // 204 No Content is a common response for successful DELETE requests
        //}
    }
    
}

