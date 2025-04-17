using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusnessLogicLayer.DTO
{
   public class UpdateDepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string code { get; set; } = string.Empty;
        public DateTime DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}
