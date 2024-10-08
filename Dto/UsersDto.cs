﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MojammatApi.Dto
{
	public class UsersDto
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

        [Required,MaxLength(100)]

        public string role { get; set; }


        public bool status { get; set; }

        public string? avatar { get; set; }
    }
}

