using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OrderFood_web_API.Models;
using OrderFood_web_API.Repository;
using OrderFood_web_API.Services;
using System.Text;

namespace OrderFood_web_API
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
            services.AddHttpClient();
            services.AddScoped<IOrderFoodRepository, OrderFoodRepository>();
            services.AddScoped<IOrderFoodService, OrderFoodService>();
            services.AddCors(options => options.AddPolicy("AllowCors", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddScoped<DatabaseContext>();
            services.AddSwaggerGen(x => x.SwaggerDoc("OrderFoodAPI",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "OrderFood API"
                }));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_my_secret_key"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,

                ValidateIssuer = true,
                ValidIssuer = "UserWebApi",

                ValidateAudience = true,
                ValidAudience = "CustomerWebApi"
            });
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
            app.UseCors("AllowCors");
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/OrderFoodAPI/swagger.json", "OrderFood API");
            });
            app.UseAuthentication().UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
