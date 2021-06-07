using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class work
    {
		[Key]

		[Column(Order = 1)]
		public int CourseId { get; set; }

		[Key]
		[Column(Order = 2)]
		public int CatagloryId { get; set; }

		public Course Courses { get; set; }
		public Cataglory Cataglorys { get; set; }
		[Key]
		[Column(Order = 3)]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }


	}
}