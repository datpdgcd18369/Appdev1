using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Toppic
    {
		[Key]
		public int Id { get; set; }
		[Required]
		public string Description { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public int CourseId { get; set; }
		public Course Course { get; set; }

	}
}