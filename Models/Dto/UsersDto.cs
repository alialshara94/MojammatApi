using System;
using System.ComponentModel.DataAnnotations;

namespace MojammatApi.Models.Dto
{
	public class UsersDto
	{
        [Required,MaxLength(100)]

        public string Fullname { get; set; }

        [MaxLength(100)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(100)]

        public string? ApartmentNo { get; set; }

        [MaxLength(100)]

        public string? Identification { get; set; }

        [MaxLength(100)]

        public string? Building { get; set; }

        [MaxLength(100)]

        public string? Floor { get; set; }

        [MaxLength(100)]

        public required string Role { get; set; }


        public bool Status { get; set; }

        public string? Avatar { get; set; }
    }
}

