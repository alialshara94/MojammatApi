using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojammatApi.Models
{
	public class Attachments
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Url { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //public Guid AppSettingId { get; set; } // Required foreign key property

        public AppSetting appSetting { get; set; } = null!; // Required reference navigation to principal

    }
}

