using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MojammatApi.Models
{
	public class Invoices
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [MaxLength(100)]

        public string title { get; set; }

        [MaxLength(100)]

        public string number { get; set; }

        [Precision(16, 2)]

        public decimal price { get; set; }

        public DateOnly date { get; set; }

        public bool isPaid { get; set; }

        public bool status { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;
        public Users users { get; set; }
        [ForeignKey("users")]
        public Guid userId { get; set; }
    }
}

