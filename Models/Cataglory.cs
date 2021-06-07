using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApplication1.UniqueAttribute.UniqueAttribute;

namespace WebApplication1.Models
{
    public class Cataglory
    {
		[Key]
		public int Id { get; set; }
		[Required]
		public string Description { get; set; }

		[Required]
		[Unique]
		public string Name { get; set; }
	}
}