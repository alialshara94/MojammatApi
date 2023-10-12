using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MojammatApi.Dto.AppSettings;
using MojammatApi.Interfaces;
using MojammatApi.Repositories;

namespace MojammatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class AppSettingController : ControllerBase
    {
        private readonly IAppSettingRepository appSettingRepository;
        private readonly IMapper mapper;

        public AppSettingController(IAppSettingRepository appSettingRepository, IMapper mapper)
        {
            this.appSettingRepository = appSettingRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddAppSettingWithAttachments([FromForm] CreateAppSettingDto appSettingDto)
        {
            var appSetting = await appSettingRepository.AddAppSettingWithAttachmentsAsync(appSettingDto);
            return Created($"/api/appsettings/{appSetting.id}", appSetting);
        }


        [HttpGet]
        public IActionResult GetAllAppSettings([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var appSettingsWithAttachments = appSettingRepository.GetAllAppSettingsWithAttachments(page, pageSize);
            return Ok(appSettingsWithAttachments);
        }
    }
}
