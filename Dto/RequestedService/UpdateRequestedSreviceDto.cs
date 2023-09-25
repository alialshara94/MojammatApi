using System.Net.NetworkInformation;

namespace MojammatApi.Dto.RequestedService
{
    public class UpdateRequestedSreviceDto
    {
        private string? _date = string.Empty;
        private string? _status = string.Empty;
        private string? _userId = string.Empty;

        public string title { get; set; } = string.Empty;



        public string description { get; set; } = string.Empty;



        public string type { get; set; } = string.Empty;



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
