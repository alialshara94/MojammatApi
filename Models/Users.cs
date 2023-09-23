using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Hosting;

namespace MojammatApi.Models
{
	public class Users
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [MaxLength(100)]

        public string fullname { get; set; }

        [MaxLength(100)]

        public string phone { get; set; }
        //[MaxLength(100)]

        //public string password { get; set; }

        [MaxLength(100)]

        public string apartmentNo { get; set; }

        [MaxLength(100)]

        public string identification { get; set; }

        [MaxLength(100)]

        public string building { get; set; }

        [MaxLength(100)]

        public string floor { get; set; }

        [MaxLength(100)]
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public string role { get; set; }


        public bool status { get; set; } = true;

        public string avatar { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;
        public ICollection<RequestedServices> services { get; } = new List<RequestedServices>();
        public ICollection<Invoices> invoices { get; } = new List<Invoices>();
        public ICollection<Visitor> visitors { get; } = new List<Visitor>();


    }
}

