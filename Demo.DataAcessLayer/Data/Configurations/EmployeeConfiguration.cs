using Demo.DataAcessLayer.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)");//max length is 50
            builder.Property(E => E.Address).HasColumnType("varchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");


            builder.Property(E => E.gender).HasConversion((empGender) => empGender.ToString(),//for enum
            (returnedEmpGender) => (Gender)Enum.Parse(typeof(Gender), returnedEmpGender));

            builder.Property(E => E.employeeType).HasConversion((empType) => empType.ToString(),//for enum
              (returnedEmpType) => (EmployeeType)Enum.Parse(typeof(EmployeeType), returnedEmpType));

            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()");

        }
    }
}
