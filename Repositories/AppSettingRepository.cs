using Microsoft.EntityFrameworkCore;
using MojammatApi.Dto.AppSettings;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Services;

namespace MojammatApi.Repositories
{
    public class AppSettingRepository : IAppSettingRepository
    {

        private readonly AppDbContext appDbContext;
        public AppSettingRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<AppSetting> AddAppSettingWithAttachmentsAsync(CreateAppSettingDto appSettingDto)
        {
            var appSetting = new AppSetting
            {
                title = appSettingDto.title,
                description = appSettingDto.description
            };

            foreach (var attachmentFile in appSettingDto.attachments)
            {
                // Define a unique name for the file
                var uniqueFileName = $"{Guid.NewGuid()}_{attachmentFile.FileName}";

                // Define the save path
                var savePath = Path.Combine("wwwroot", "Upload", "Files", uniqueFileName);

                // Save the file
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    await attachmentFile.CopyToAsync(fileStream);
                }

                var attachment = new Attachments
                {
                    url = uniqueFileName, // Now, the URL field will contain the unique file name
                    status = true, // You can set this based on your requirements
                    appSetting = appSetting
                };

                appSetting.attachments.Add(attachment);
            }

            appDbContext.Add(appSetting);
            await appDbContext.SaveChangesAsync();

            return appSetting;
        }

        public IEnumerable<AppSetting> GetAllAppSettingsWithAttachments(int page, int pageSize)
        {
            return appDbContext.appSettings
        .Include(a => a.attachments)
        .OrderBy(a => a.createdAt)  // Sorting in ascending order
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToList();
        }
    }
}
