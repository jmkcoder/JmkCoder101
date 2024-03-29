using Components.Common;
using Microsoft.Extensions.FileProviders;

namespace JmkCoder101
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            _ = new RazorPageRenderer(app.Services);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Serve static files from wwwroot of component library
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Nimbus")),
                RequestPath = "/component"
            });

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Example}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/GettingStarted");
                    return Task.CompletedTask;
                });
            });

            app.Run();
        }
    }
}