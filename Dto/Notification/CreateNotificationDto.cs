using System.ComponentModel.DataAnnotations;

namespace MojammatApi.Dto.Notification
{
    public class CreateNotificationDto
    {
       

        public string title { get; set; }

        public string description { get; set; }


        public bool status { get; set; }
    }
}
