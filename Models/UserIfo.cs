using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserIfo
    {
		
			[Key]
			[ForeignKey("User")]
			public string UserId { get; set; }
			public ApplicationUser User { get; set; }
			public string FullName { get; set; }
			[Range(18, 60, ErrorMessage = "Age must be between 25 and 60")]
			public int Age { get; set; }
			
	}
}