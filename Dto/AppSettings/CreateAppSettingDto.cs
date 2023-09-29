namespace MojammatApi.Dto.AppSettings
{
    public class CreateAppSettingDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<IFormFile> attachments { get; set; } = new List<IFormFile>();
    }
}
