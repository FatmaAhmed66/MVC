using Demo.DataAcessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace persentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            //1)when to use addsingleton? 1- for services that log exception to tell user and send me that there is an exception in any request 
                                       // 2- in caching
            //builder.Services.AddSingleton<AppDBCONTEXT>();// object remained in heap for lifetiem of application

           /* builder.Services.AddScoped<AppDBCONTEXT>();*///this is the service to use dependency injection
                                                       //liftime for object per request

            //builder.Services.AddTransient < AppDBCONTEXT>();//object lifetime per operation in per request
            //the best on so for is addscoped
            builder.Services.AddDbContext<AppDBCONTEXT>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}