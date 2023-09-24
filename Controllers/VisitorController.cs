using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MojammatApi.Dto;
using MojammatApi.Dto.Visitors;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Services;

namespace MojammatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
        {

        private readonly AppDbContext _appDbContext;
       
        private readonly IVisitorRepository visitorRepository;
        private readonly IMapper mapper;

        public VisitorController(IVisitorRepository visitorRepository, IMapper mapper, AppDbContext appDbContext)
        {
            this.visitorRepository = visitorRepository;
            this.mapper = mapper;
            this._appDbContext = appDbContext;
        }



        [HttpGet]

        public IActionResult GetVisitors([FromQuery] string? search,[FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var visitor = mapper.Map<List<GetVisitorDto>>(visitorRepository.GetVisitors(page, pageSize,search));

            return Ok(visitor);
        }


        [HttpGet("{id:Guid}", Name = "GetVisitorById")]
        public IActionResult GetVisitorById(Guid id)
        {
            var visitor = mapper.Map<GetVisitorDto>(visitorRepository.GetVisitor(id));

            if (visitor == null)
            {
                return NotFound();
            }
            return Ok(visitor);
        }

        [HttpPost]
        public IActionResult CreateVisitor([FromForm] CreateVisitorDto createVisitorDto)
        {


            var visitor = mapper.Map<Visitor>(createVisitorDto);

            visitorRepository.CreateVisitor(visitor);

            return Ok("created visitor seccessfuly");
        }


        [HttpPatch("{id:Guid}",Name = "updateVisitor")]
        public IActionResult UpdateUsers(Guid id, [FromBody] JsonPatchDocument<UpdateVisitorDto> patchDoc)
        {

            //var visitors = mapper.Map<Visitor>(updateVisitorDto);


            //if (visitorRepository.UpdateVisitor(updateVisitorDto, id))
            //{
            //    return Ok();
            //}
            //return NotFound();

            if (patchDoc == null)
            {
                return BadRequest();
            }

            var visitorFromDb = _appDbContext.visitors.FirstOrDefault(v => v.id == id);

            if (visitorFromDb == null)
            {
                return NotFound();
            }

            var visitorToPatch = new UpdateVisitorDto
            {
                fullname = visitorFromDb.fullname,
                inDate = visitorFromDb.inDate,
                inTime = visitorFromDb.inTime,
                outDate = visitorFromDb.outDate,
                outTime = visitorFromDb.outTime,
                status = visitorFromDb.status,
                userId = visitorFromDb.userId
            };

            patchDoc.ApplyTo(visitorToPatch);

            // Map the patched object to the original visitor entity
            visitorFromDb.fullname = visitorToPatch.fullname;
            visitorFromDb.inDate = visitorToPatch.inDate;
            visitorFromDb.inTime = visitorToPatch.inTime;
            visitorFromDb.outDate = visitorToPatch.outDate;
            visitorFromDb.outTime = visitorToPatch.outTime;
            visitorFromDb.status = visitorToPatch.status;
            visitorFromDb.userId = visitorToPatch.userId;

            _appDbContext.SaveChanges();

            return NoContent();
        }

        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpDelete("{id:Guid}", Name = "DeleteUser")]
        //public IActionResult DeleteUser(Guid id)
        //{
        //    var user = userRepository.DeleteUser(id);
        //    Console.WriteLine(user);

        //    return Ok();
        //}
    }
    
}

