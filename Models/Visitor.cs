using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojammatApi.Models
{
	public class Visitor
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(100)]

        public string VFullname { get; set; }

        public DateOnly InDate { get; set; }

        public TimeOnly InTime { get; set; }

        public DateOnly OutDate { get; set; }

        public TimeOnly OutTime { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public Guid UserId { get; set; } // Required foreign key property

        public Users users { get; set; } = null!; // Required reference navigation to principal
    }
}

