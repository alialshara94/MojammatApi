using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojammatApi.Models
{
    public class RequestedServices
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]

        public string Description { get; set; }

        [MaxLength(100)]

        public string Type { get; set; }



        public DateOnly Date { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //public Guid UserId { get; set; } // Required foreign key property

        public Users   users { get; set; } = null!; // Required reference navigation to principal
    }
}

