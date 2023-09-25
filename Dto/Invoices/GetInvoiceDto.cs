using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MojammatApi.Dto.Invoices
{
    public class GetInvoiceDto
    {
        public Guid id { get; set; }
        public string title { get; set; }

        public string number { get; set; }


        public decimal price { get; set; }

        public DateOnly date { get; set; }

        public bool isPaid { get; set; }

        public bool status { get; set; }

        public DateTime createdAt { get; set; }
 
        public Guid userId { get; set; }
    }
}
