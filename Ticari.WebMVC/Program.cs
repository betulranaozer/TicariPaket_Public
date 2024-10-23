using Microsoft.EntityFrameworkCore;
using Ticari.Entities.DbContexts;
using Ticari.WebMVC.Extensions;

namespace Ticari.WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region DbContext Registiration
            var constr = builder.Configuration.GetConnectionString("Ticari");
            builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(constr)); 
            #endregion



           builder.Services.AddTicariService();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(

                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}
