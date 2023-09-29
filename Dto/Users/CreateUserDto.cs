using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MojammatApi.Models;

namespace MojammatApi.Dto.Users
{
	public class CreateUserDto
	{
     

        [Required, MaxLength(100)]

        public string fullname { get; set; }

        [MaxLength(100)]
        [Required]
        public string phone { get; set; }

        [MaxLength(100)]

        public string? apartmentNo { get; set; }

        [MaxLength(100)]

        public string? identification { get; set; }

        [MaxLength(100)]

        public string? building { get; set; }

        [MaxLength(100)]

        public string? floor { get; set; }

        [Required, MaxLength(100)]
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public string role { get; set; }


        public bool status { get; set; }

        public IFormFile image { get; set; }
    }
}

