using AllariNet.Interfaces;
using AllariNet.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AllariNet.Controllers;

namespace AllariNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        // Step 8: Register your services with dependency injection
                        services.AddScoped<IPersonService, PersonService>();
                        services.AddControllersWithViews();
                    })
                    .Configure(app =>
                    {
                        var env = app.ApplicationServices.GetService<IWebHostEnvironment>();

                        if (env.IsDevelopment())
                        {
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
                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                        });
                    });
                });
    }
}
