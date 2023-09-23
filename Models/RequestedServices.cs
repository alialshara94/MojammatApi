using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojammatApi.Models
{
    public class RequestedServices
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [MaxLength(100)]
        public string title { get; set; }

        [MaxLength(100)]

        public string description { get; set; }

        [MaxLength(100)]

        public string type { get; set; }



        public DateOnly date { get; set; }


        public DateTime createdAt { get; set; } = DateTime.Now;

        public Users users { get; set; }
        [ForeignKey("users")]
        public Guid userId { get; set; }
    }
}

