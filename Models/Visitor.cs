using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojammatApi.Models
{
	public class Visitor
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [MaxLength(100)]

        public string fullname { get; set; }

        public DateOnly inDate { get; set; }

        public TimeOnly inTime { get; set; }

        public DateOnly outDate { get; set; }

        public TimeOnly outTime { get; set; }

        public bool status { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        public Users users { get; set; }
        [ForeignKey("users")]
        public Guid userId { get; set; } 

    }
}

