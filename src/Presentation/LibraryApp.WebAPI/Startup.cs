using AutoMapper;
using FluentValidation.AspNetCore;
using LibraryApp.Application;
using LibraryApp.Application.AutoMapper;
using LibraryApp.Application.AutoMapper.Profiles;
using LibraryApp.Application.FluentValidation;
using LibraryApp.Application.FluentValidation.UserValidation;
using LibraryApp.Application.Interfaces;
using LibraryApp.Application.Interfaces.Manager;
using LibraryApp.Persistence;
using LibraryApp.Persistence.Repositories;
using LibraryApp.Persistence.Repositories.Entityframework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using LibraryApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using LibraryApp.Application.Extensions;

namespace LibraryApp.WebAPI
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
            services.AddDbContext<LibraryDatabaseContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));

            services
    .AddControllers()
     .AddJsonOptions(opt =>
     {
         opt.JsonSerializerOptions.PropertyNamingPolicy = null;
     })
    .AddFluentValidation();

            services.AddApplicationRegistration();

            //AutoMapper registration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BookProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<UserProfile>();

            });
            services.AddSingleton(config.CreateMapper());



            services.LoadServices();
            services.LoadRepository(Configuration);

            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<BookAddDtoValidator>());
            services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CategoryAddDtoValidator>());
            services.AddControllers().AddFluentValidation(y => y.RegisterValidatorsFromAssemblyContaining<UserAddDtoValidator>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryApp.WebAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
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
