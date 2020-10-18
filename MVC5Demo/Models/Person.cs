using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="請輸入姓名")]
        [MaxLength(5,ErrorMessage ="姓名長度最長{1}")]
        [MinLength(2,ErrorMessage = "姓名長度最短{1}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "請輸入年紀")]
        [Range(18,99,ErrorMessage = "最少需在{1}歲以上，{2}歲以下")]
        public int Age { get; set; }
    }
}