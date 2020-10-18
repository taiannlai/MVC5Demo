using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class Person
    {
        public int Id { get; set; }
        [DisplayName("姓名")]
        [Required(ErrorMessageResourceName = "Person_Name_Required", ErrorMessageResourceType = typeof(Resource1))]
        [MaxLength(5,ErrorMessage ="姓名長度最長{1}")]
        [MinLength(2,ErrorMessage = "姓名長度最短{1}")]
        public string Name { get; set; }
        [DisplayName("年齡")]
        [Required(ErrorMessage = "請輸入年紀")]
        [Range(18,99, ErrorMessageResourceName = "Person_Year_Required", ErrorMessageResourceType = typeof(Resource1))]
        public int Age { get; set; }
    }
}