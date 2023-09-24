using System;
using System.ComponentModel.DataAnnotations;

namespace MojammatApi.Dto.Visitors
{
	public class CreateVisitorDto
	{

        [Required,MaxLength(255)]
        public string fullname { get; set; }

        [Required]
        public DateOnly inDate { get; set; }
        
        public TimeOnly inTime { get; set; }


        public DateOnly outDate { get; set; }

        public TimeOnly outTime { get; set; }

        public bool status { get; set; }


        //public Users users { get; set; }
        //[ForeignKey("users")]
        public Guid userId { get; set; }
    }
}

