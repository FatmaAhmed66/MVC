using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusnessLogicLayer.DTO
{
    public class CreatedDepartmentDTO
    {
        [Required (ErrorMessage =" YOUR NAME IS REQUIRED !!")]
        public string Name { get; set; } = null!;

        public string code { get; set; } = null!;
        public DateTime DateOfCreation { get; set; }
        public string? Description { get; set; }

    }
}
