using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.viewmodel
{
  public class ToppicCourseViewmodel
  {
    public Toppic Toppic { get; set; }
    public IEnumerable<Course> Courses { get; set; }
   

  }
  public class CateloryCreateViewmodel
  {
    [Required]
    public int CateloryId { get; set; }
    public string Course { get; set; }
    public IEnumerable<Course> course { get; set; }
  }
}