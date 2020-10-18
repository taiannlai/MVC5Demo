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
        public string Name { get; set; }
        [Required(ErrorMessage = "請輸入年紀")]
        [Range(18,99,ErrorMessage = "最少需在18歲以上，99歲以下")]
        public int Age { get; set; }
    }
}