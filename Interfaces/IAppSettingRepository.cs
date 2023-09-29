

using MojammatApi.Dto.AppSettings;
using MojammatApi.Models;

namespace MojammatApi.Interfaces
{
    public interface IAppSettingRepository
    {
        Task<AppSetting> AddAppSettingWithAttachmentsAsync(CreateAppSettingDto appSettingDto);
        
        IEnumerable<AppSetting> GetAllAppSettingsWithAttachments(int page, int pageSize);
        //Invoices GetInvoice(Guid id);
        //bool CreateInvoice(AppSetting appSetting);
        //bool UpdateInvoice(UpdateInvoiceDto updateInvoiceDto, Guid id);
        //bool DeleteInvoice(Guid id);
    }
}
