using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojammatApi.Models
{
	public class AppSetting
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [MaxLength(100)]

        public string title { get; set; }

        public string description { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public ICollection<Attachments> attachments { get; } = new List<Attachments>();


    }
}

