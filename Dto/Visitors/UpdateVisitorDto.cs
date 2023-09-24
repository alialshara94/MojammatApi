using System;
namespace MojammatApi.Dto.Visitors
{
	public class UpdateVisitorDto
	{
        public string fullname { get; set; }

        
        public DateOnly inDate { get; set; }

        public TimeOnly inTime { get; set; }


        public DateOnly outDate { get; set; }

        public TimeOnly outTime { get; set; }

        public bool status { get; set; }
        public Guid userId { get; set; }

    }
}

