using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UsersMicroservice.Models;
using UsersMicroservice.Repository;
using UsersMicroservice.Service;

namespace UsersMicroservice
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenGenerator, TokenService>();

            var connectionStr = Environment.GetEnvironmentVariable("SQL_DB");
            if (connectionStr == null)
            {
                connectionStr = Configuration.GetConnectionString("con");
            }

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionStr));
            services.AddSwaggerGen(x => x.SwaggerDoc("UserAPI",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "User API"
                }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/UserAPI/swagger.json", "UserAPI API");
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
