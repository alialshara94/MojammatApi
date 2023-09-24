namespace MojammatApi.Dto.Visitors
{
    public class GetVisitorDto
    {
        public Guid id { get; set; }
        public string fullname { get; set; }

        public DateOnly inDate { get; set; }

        public TimeOnly inTime { get; set; }

        public DateOnly outDate { get; set; }

        public TimeOnly outTime { get; set; }

        public bool status { get; set; }

        public DateTime createdAt { get; set; }

        //public Users users { get; set; }
        //[ForeignKey("users")]
        public Guid userId { get; set; }
    }
}

