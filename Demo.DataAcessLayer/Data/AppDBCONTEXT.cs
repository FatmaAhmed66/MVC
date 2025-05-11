using Demo.DataAcessLayer.Data.Configurations;
using Demo.DataAcessLayer.Models;
using Demo.DataAcessLayer.Models.EmployeeModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Data
{
    public class AppDBCONTEXT : IdentityDbContext<ApplicationUser>
    {

        public AppDBCONTEXT(DbContextOptions<AppDBCONTEXT> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.;Database=MVC;Trusted_Connection=true;");

            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
        //public DbSet<IdentityUser> users { get; set; }
        //public DbSet<IdentityRole> roles { get; set; }
    }
}
