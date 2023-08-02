using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tehnoforest.Data;
using Tehnoforest.Data.Models;
using Tehnoforest.Services.Data;
using Tehnoforest.Services.Data.Interfaces;
using Tehnoforest.Web.Infrastructure.Extensions;
using Tehnoforest.Web.Infrastructure.ModelBinders;
using static Tehnoforest.Common.GeneralApplicationConstants;

namespace Tehnoforest
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services
                .AddDbContext<TehnoforestDbContext>(options =>
                options.UseSqlServer(connectionString));


            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount =
                    builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<TehnoforestDbContext>();

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
            });

            builder.Services.AddScoped<IChainsawService, ChainsawService>();
            builder.Services.AddScoped<IAutomowerService, AutomowerService>();
            builder.Services.AddScoped<IGardenTractorService, GardenTractorService>();
            builder.Services.AddScoped<IGrassTrimmerService, GrassTrimmerService>();
            builder.Services.AddScoped<ILawnMowerService, LawnMowerService>();
            builder.Services.AddScoped<IRepairServiceProductService, RepairServiceProductService>();

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                });

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedAdministrator(DevelopmentAdminEmail);

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}

