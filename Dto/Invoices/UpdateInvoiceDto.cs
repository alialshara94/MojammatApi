namespace MojammatApi.Dto.Invoices
{
    public class UpdateInvoiceDto
    {
        private string? _date = string.Empty;
        private string? _isPaid = string.Empty;
        private string? _status = string.Empty;
        private string? _userId = string.Empty;
        private string? _price = string.Empty;

        public string title { get; set; } = string.Empty;
        public string number { get; set; } = string.Empty;

        public string? price
        {
            get => _price;
            set
            {
                if (value is not null && !decimal.TryParse(value, out _))
                {
                    throw new ArgumentException("Invalid price format. Must be a valid decimal.");
                }
                _price = value;
            }
        }

        public string? date
        {
            get => _date;
            set
            {
                if (!DateOnly.TryParse(value, out _))
                {
                    throw new ArgumentException("Invalid date format.");
                }
                _date = value;
            }
        }

        public string? isPaid
        {
            get => _isPaid;
            set
            {
                if (!bool.TryParse(value, out _))
                {
                    throw new ArgumentException("Invalid isPaid value. Must be 'true' or 'false'.");
                }
                _isPaid = value;
            }
        }

        public string? status
        {
            get => _status;
            set
            {
                if (!bool.TryParse(value, out _))
                {
                    throw new ArgumentException("Invalid status value. Must be 'true' or 'false'.");
                }
                _status = value;
            }
        }

        public string? userId
        {
            get => _userId;
            set
            {
                if (value is not null && !Guid.TryParse(value, out _))
                {
                    throw new ArgumentException("Invalid userId format. Must be a valid GUID.");
                }
                _userId = value;
            }
        }
    }
}
