namespace MojammatApi.Dto.Notification
{
    public class GetNotificationDto
    {

        public Guid id { get; set; }
        public string title { get; set; }

        public string description { get; set; }


        public bool status { get; set; }
        public DateTime createdAt { get; set; }

    }
}
