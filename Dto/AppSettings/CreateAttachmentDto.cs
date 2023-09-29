namespace MojammatApi.Dto.AppSettings
{
    public class CreateAttachmentDto
    {
        public IFormFile url { get; set; }
        public bool status { get; set; } = true;
    }
}
