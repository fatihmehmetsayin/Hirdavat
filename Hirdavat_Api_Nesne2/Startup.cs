
using Hirdavat.Core.Repositories;
using Hirdavat.Core.Servisler;
using Hirdavat.Core.UnitOfWorks;
using Hirdavat.Data;
using Hirdavat.Data.Repositories;
using Hirdavat.Data.UnitOfWork;
using Hirdavat.Servis.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Hirdavat_Api_Nesne2.Filters;
using Hirdavat_Api_Nesne2.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hirdavat_Api_Nesne2
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
            //e�er filter DI nesnesi al�yorsa starup taraf�nda add scpoe eklenmelidir
            //daha sonra aciton metot �zerinde yaz�lmas� yeterlidir.
            // ValidateIssuer = false, ValidateAudience = false

            //depenci �njection nesnesi ald��ndan dolay� buraya kaydedebilirim
            // bu filter  i�erisinde ctorunda bir interface implement al�yor 
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());


            });
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))


                    };


                }); 
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            //e�er filter DI nesnesi al�yorsa starup taraf�nda add scpoe eklenmelidir
            //daha sonra aciton metot �zerinde yaz�lmas� yeterlidir.
            //depenci �njection nesnesi ald��ndan dolay� buraya kaydedebilirim
            // bu filter  i�erisinde ctorunda bir interface implement al�yor
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(Iservice<>), typeof(Service<>));
            services.AddScoped<ICategoryServis, CategoryService>();
            services.AddScoped<IProductServis, ProductService>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase(Configuration.GetConnectionString("memory"));
            });

            services.AddScoped<IunitOfWork, UnitOfWork>();
            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(o =>

            {

                // filter kontrol etme ben edicem hatay� kendim ele al�cam sen kar��ma anlam�nda 
                o.SuppressModelStateInvalidFilter = true;


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //tek metoda indirdim   
            app.UxeException();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
