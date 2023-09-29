using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MojammatApi.Models
{
    public class PushNotifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [MaxLength(100)]

        public string title { get; set; }

        public string description { get; set; }


        public bool status { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

    }
}
