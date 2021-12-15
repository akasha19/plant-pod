using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlantPodService.Model;
using PlantPodService.Services;
using PlantPodService.Services.Persistence;
using System;

namespace PlantPodService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
			services.AddSingleton<ILiveDataService, LiveDataService>();
            services.AddSingleton<IRoomsService, RoomsService>();

            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite($"Data Source={System.IO.Path.Join(path, Configuration.GetConnectionString("PlantPodDatabase"))}"));        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
