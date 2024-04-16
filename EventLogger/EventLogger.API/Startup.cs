using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventLogger.Domain.IRepositories;
using EventLogger.Infrastructure;
using EventLogger.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventLogger.API
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<EventLoggerDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

           

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}