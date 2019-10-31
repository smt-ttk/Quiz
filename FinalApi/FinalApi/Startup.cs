using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalApi.Context;
using FinalApi.Interfaces;
using FinalApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinalApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IRepository, Repository>();

            services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=BIS-1011768657;Database=Final_JWT;Trusted_Connection=True;"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options =>
            options.WithOrigins("http://localhost:5000")
            .AllowAnyHeader()
            .AllowAnyMethod());
            app.UseMvc();
        }
    }
}
