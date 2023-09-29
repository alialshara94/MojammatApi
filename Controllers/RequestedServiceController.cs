using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MojammatApi.Dto.RequestedService;
using MojammatApi.Dto.Visitors;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Repositories;
using System.ComponentModel.DataAnnotations;

namespace MojammatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestedServiceController : ControllerBase
    {
        private readonly IRequestedServiceRepository requestedServiceRepository;
        private readonly IMapper mapper;

        public RequestedServiceController(IRequestedServiceRepository requestedServiceRepository, IMapper mapper)
        {
            this.requestedServiceRepository = requestedServiceRepository;
            this.mapper = mapper;
        }



        [HttpGet]

        public IActionResult GetServices([FromQuery] string? type, [FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var visitor = mapper.Map<List<GetRequestedServiceDto>>(requestedServiceRepository.GetServices(page, pageSize, type));

            return Ok(visitor);
        }

        [HttpPost]
        public IActionResult CreateService([FromForm] CreateRequestedServiceDto createRequestedServiceDto)
        {


            var service = mapper.Map<RequestedServices>(createRequestedServiceDto);
            requestedServiceRepository.CreateService(service);

            return Ok("created service seccessfuly");
        }


        [HttpGet("{id:Guid}",Name = "GetServiceById")]
        public IActionResult GetServiceById(Guid id)
        {
            var service = mapper.Map<GetRequestedServiceDto>(requestedServiceRepository.GetService(id));

            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }


        [HttpGet("/byUser/{userId:Guid}", Name = "GetServiceByUserId")]
        public IActionResult GetServiceByUserId(Guid userId)
        {
            var service = requestedServiceRepository.GetServiceByUser(userId);

            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPut(Name = "updateService")]
        public IActionResult UpdateService([FromBody] UpdateRequestedSreviceDto updateRequestedSreviceDto, [FromQuery, Required] Guid serviceId)
        {
            var res = requestedServiceRepository.UpdateService(updateRequestedSreviceDto, serviceId);
            if (res)
            {
                return Ok("updated Successfully");
            }
            else
            {
                return NotFound("The Service is Not Found");
            }
        }

        [HttpDelete("{id:Guid}", Name = "DeleteService")]
        public IActionResult DeleteService(Guid id)
        {
            var visitor = requestedServiceRepository.DeleteService(id);
            //Console.WriteLine(user);

            return Ok();
        }

    }
}

