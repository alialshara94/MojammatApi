namespace MojammatApi.Dto.Users
{
	public class UpdateUserDto
	{
        private string? _status = string.Empty;

        public string? fullname { get; set; } = string.Empty;

        public string? phone { get; set; } = string.Empty;

        public string? apartmentNo { get; set; } = string.Empty;

        public string? identification { get; set; } = string.Empty;

        public string? building { get; set; } = string.Empty;

        public string? floor { get; set; } = string.Empty;

        public string? role { get; set; } = string.Empty;

        public string? status {
            get
            {
                return _status;
            }
            set
            {
                if (value is not null && !bool.TryParse(value, out _))
                {
                    throw new ArgumentException("The status value must be 'true' or 'false'.");
                }
                _status = value;
            }
        }

        //public string avatar { get; set; } = string.Empty;
    }
}

