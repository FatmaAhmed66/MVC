using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } //PK
        public int CreatedBy { get; set; } //USER ID
        public DateTime CreatedOn { get; set; } //Time of Creation
        public int LastModifiedBy { get; set; } //user id

        public DateTime LastModifiedOn { get; set; } //Time of Modification
        public bool IsDeleted { get; set; } //soft Delete
    }
}
