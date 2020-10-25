using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class CourseEdit
    {
        [Required]
        public int CourseID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public string Memo { get; set; }

    }
}