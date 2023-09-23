using System;
using System.ComponentModel.DataAnnotations;

namespace MojammatApi.Dto.Users
{
	public class GetUserDto
	{

        public Guid id { get; set; }
        public string fullname { get; set; }

     
        public string phone { get; set; }

 

        public string apartmentNo { get; set; }



        public string identification { get; set; }


        public string building { get; set; }



        public string floor { get; set; }



        public  string role { get; set; }


        public bool status { get; set; }

        public string avatar { get; set; }
    }
}

