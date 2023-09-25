using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MojammatApi.Dto.Visitors;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Services;
using System.ComponentModel.DataAnnotations;

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


        [HttpPut(Name = "updateVisitor")]
        public IActionResult UpdateVisitor([FromBody] UpdateVisitorDto updateVisitorDto, [FromQuery, Required] Guid visitorId)
        {
            var res = visitorRepository.UpdateVisitor(updateVisitorDto, visitorId);
            if (res)
            {
                return Ok("updated Successfully");
            }
            else
            {
                return NotFound("The visitor is Not Found");
            }
        }

        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:Guid}", Name = "DeleteVisitor")]
        public IActionResult DeleteService(Guid id)
        {
            var visitor = visitorRepository.DeleteVisitor(id);
            //Console.WriteLine(user);

            return Ok();
        }
    }
    
}

