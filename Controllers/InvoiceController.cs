using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MojammatApi.Dto.Invoices;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Repositories;
using MojammatApi.Services;
using System.ComponentModel.DataAnnotations;

namespace MojammatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InvoiceController : ControllerBase
    {

        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public InvoiceController(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetInvoices([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var invoices = mapper.Map<List<GetInvoiceDto>>(invoiceRepository.GetInvoices(page, pageSize, search));
            return Ok(invoices);
        }

        [HttpGet("byUser/{userId:Guid}", Name = "GetInvoiceByUserId")]
        public IActionResult GetInvoiceByUserId(Guid userId)
        {
            var invoice = invoiceRepository.GetInvoiceByUserId(userId);

            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpGet("{id:Guid}", Name = "GetInvoiceById")]
        public IActionResult GetInvoiceById(Guid id)
        {
            var invoice = mapper.Map<GetInvoiceDto>(invoiceRepository.GetInvoice(id));

            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateInvoice([FromForm] CreateInvoiceDto createInvoiceDto)
        {
            var invoice = mapper.Map<Invoices>(createInvoiceDto);
            invoiceRepository.CreateInvoice(invoice);

            return Ok("created invoice successfully");
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut(Name = "updateInvoice")]
        public IActionResult UpdateInvoice([FromBody] UpdateInvoiceDto updateInvoiceDto, [FromQuery, Required] Guid invoiceId)
        {
            var res = invoiceRepository.UpdateInvoice(updateInvoiceDto, invoiceId);
            if (res)
            {
                return Ok("updated Successfully");
            }
            else
            {
                return NotFound("The invoice is Not Found");
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id:Guid}", Name = "DeleteInvoice")]
        public IActionResult DeleteInvoice(Guid id)
        {
            var invoice = invoiceRepository.DeleteInvoice(id);
            return Ok();
        }
    }
}
