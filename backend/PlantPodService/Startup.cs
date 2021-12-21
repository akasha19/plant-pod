using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlantPodService.Model;
using PlantPodService.Services;
using PlantPodService.Services.Persistence;
using PlantPodService.ViewModel;

namespace PlantPodService
{
    public class Startup
    {
        private const string DefaultCorsPolicy = "DefaultCorsPolicy";

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

            services.AddSingleton<IRoomService, RoomService>();
            services.AddSingleton<IPlantService, PlantService>();
             
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<PlantPodServiceDbContext>(op => op.UseSqlServer(Configuration["ConnectionString:PlantPodServiceDb"]), optionsLifetime: ServiceLifetime.Singleton, contextLifetime: ServiceLifetime.Singleton);
            services.AddSingleton<DbContext>(sp => sp.GetRequiredService<PlantPodServiceDbContext>());

            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        DefaultCorsPolicy,
                        builder =>
                        {
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(DefaultCorsPolicy);

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
