using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MojammatApi.Dto.Invoices;
using MojammatApi.Dto.Notification;
using MojammatApi.Helper;
using MojammatApi.Hubs;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Repositories;

namespace MojammatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;

        public NotificationController(INotificationRepository notificationRepository, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNotificatoin([FromForm] CreateNotificationDto createNotificationDto,  IHubContext<NotificationHub, INotificationHub> context)
        {
            try
            {

                var notification = mapper.Map<PushNotifications>(createNotificationDto);
                notificationRepository.CreateNotification(notification);
                await context.Clients.All.ReceiveNotification("ali",createNotificationDto.title,createNotificationDto.description);

                return Ok("created invoice successfully");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }

        [HttpGet]
        public IActionResult GetNotifications([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var notification = mapper.Map<List<GetInvoiceDto>>(notificationRepository.GetNotifications(page, pageSize, search));
            return Ok(notification);
        }



        [HttpGet("{id:Guid}", Name = "GetNotificationById")]
        public IActionResult GetNotificationById(Guid id)
        {
            var notification = mapper.Map<GetNotificationDto>(notificationRepository.GetNotification(id));

            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:Guid}", Name = "DeleteNotification")]
        public IActionResult DeleteNotification(Guid id)
        {
            var notification = notificationRepository.DeleteNotification(id);
            return Ok();
        }

    }
}
