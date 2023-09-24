using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MojammatApi.Dto.RequestedService;
using MojammatApi.Dto.Visitors;
using MojammatApi.Interfaces;
using MojammatApi.Models;

namespace MojammatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

    }
}

