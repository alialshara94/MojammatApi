namespace MojammatApi.Dto.Invoices
{
    public class CreateInvoiceDto
    {

        public string title { get; set; } = string.Empty;

        public string number { get; set; } = string.Empty;


        public decimal price { get; set; }

        public DateOnly date { get; set; }

        public bool isPaid { get; set; }

        public bool status { get; set; }


        public Guid userId { get; set; }
    }
}
