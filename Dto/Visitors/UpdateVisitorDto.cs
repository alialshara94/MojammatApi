using System;
namespace MojammatApi.Dto.Visitors
{
	public class UpdateVisitorDto
	{
        private string? _inDate = string.Empty;
        private string? _inTime = string.Empty;
        private string? _outDate = string.Empty;
        private string? _outTime = string.Empty;
        private string? _status = string.Empty;
        private string? _userId = string.Empty;

        public string? fullname { get; set; } = string.Empty;

        public string? inDate
        {
            get => _inDate;
            set
            {
                if (!DateOnly.TryParse(value, out _))
                {
                    throw new ArgumentException("Invalid inDate format.");
                }
                _inDate = value;
            }
        }

        public string? inTime
        {
            get => _inTime;
            set
            {
                if (!TimeOnly.TryParse(value, out _))
                {
                    throw new ArgumentException("Invalid inTime format.");
                }
                _inTime = value;
            }
        }

        public string? outDate
        {
            get => _outDate;
            set
            {
                if (!DateOnly.TryParse(value, out _))
                {
                    throw new ArgumentException("Invalid outDate format.");
                }
                _outDate = value;
            }
        }

        public string? outTime
        {
            get => _outTime;
            set
            {
                if (!TimeOnly.TryParse(value, out _))
                {
                    throw new ArgumentException("Invalid outTime format.");
                }
                _outTime = value;
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

