using System;
namespace MojammatApi.Dto.RequestedService
{
	public class CreateRequestedServiceDto
	{
       


        public string title { get; set; }



        public string description { get; set; }



        public string type { get; set; }



        public DateOnly date { get; set; }


        public bool status { get; set; } = true;

        public Guid userId { get; set; }
    }
}

