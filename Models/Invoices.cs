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
        public Guid Id { get; set; }

        [MaxLength(100)]

        public string Title { get; set; }

        [MaxLength(100)]

        public string Number { get; set; }

        [Precision(16, 2)]

        public decimal Price { get; set; }

        public DateOnly Date { get; set; }

        public bool IsPaid { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public Guid UserId { get; set; } // Required foreign key property

        public Users users { get; set; } = null!; // Required reference navigation to principal
    }
}

