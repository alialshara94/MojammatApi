using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Hosting;

namespace MojammatApi.Models
{
	public class Users
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(100)]

        public string Fullname { get; set; }

        [MaxLength(100)]

        public string Phone { get; set; }

        [MaxLength(100)]

        public string ApartmentNo { get; set; }

        [MaxLength(100)]

        public string Identification { get; set; }

        [MaxLength(100)]

        public string Building { get; set; }

        [MaxLength(100)]

        public string Floor { get; set; }

        [MaxLength(100)]

        public string Role { get; set; }


        public bool Status { get; set; } = true;

        public string Avatar { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<RequestedServices> services { get; } = new List<RequestedServices>();
        public ICollection<Invoices> invoices { get; } = new List<Invoices>();
        public ICollection<Visitor> visitors { get; } = new List<Visitor>();


    }
}

