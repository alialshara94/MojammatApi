using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojammatApi.Dto.RequestedService
{
	public class GetRequestedServiceDto
	{
        public Guid id { get; set; }

        
        public string title { get; set; }

        

        public string description { get; set; }

        

        public string type { get; set; }



        public DateOnly date { get; set; }


        public bool status { get; set; } = true;
       
        public Guid userId { get; set; }
    }
}

