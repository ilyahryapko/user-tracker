using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserTracker.BL.Services;
using UserTracker.DAL.Repositories;
using UserTracker.Middleware;

namespace UserTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder
                        .WithOrigins(Configuration.GetValue<string>("App:FrontendUrl"))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
            
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<ILogService, LogService>();
            services.AddControllers();
            services.AddHttpContextAccessor();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthenticationMiddleware();
            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigin");
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}