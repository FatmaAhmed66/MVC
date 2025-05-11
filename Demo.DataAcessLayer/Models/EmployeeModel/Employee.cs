using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Models.EmployeeModel
{
    public class Employee :BaseEntity
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public String? Email { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender gender { get; set; }
        public EmployeeType employeeType { get; set; }
        public virtual  Department Department { get; set; } //naviagtion property [1]
        [Required]
        [Display(Name = "Department")]
        public int?  DepartmentId { get; set; } //FK COLOUMN
       
        public string? ImageName { get; set; }


    }
}
