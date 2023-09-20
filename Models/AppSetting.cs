using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojammatApi.Models
{
	public class AppSetting
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(100)]

        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Attachments> attachments { get; } = new List<Attachments>();


    }
}

