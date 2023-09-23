using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojammatApi.Models
{
	public class Attachments
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public string url { get; set; }

        public bool status { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;


        public AppSetting appSetting { get; set; } 
        [ForeignKey("users")]
        public Guid appSettingId { get; set; }
    }
}

