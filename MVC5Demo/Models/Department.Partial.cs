using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department : IValidatableObject //因為這是department的擴充，所以該行要跟department model一樣
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name != "Will" & this.Budget > 100)
            {
                yield return new ValidationResult("您的預算不足", new string[] { "Budge" });
            }
        }
    }
    public class DepartmentMetadata
    {
        public int DepartmentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MustBeEven]
        public decimal Budget { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Required]
        public Nullable<int> InstructorID { get; set; }
        public byte[] RowVersion { get; set; }
    }
}