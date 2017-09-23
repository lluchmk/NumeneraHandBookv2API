using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using NumeneraCypherBook.Core.Data;
using NumeneraCypherBook.Core.Data.EntityFramework;

namespace NumeneraCypherBookAPI
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
            // Allow DI to inject ICypherRepository
            services.AddTransient<ICypherRepository, CypherRepository>();
            services.AddDbContext<NumeneraContext>(opt => opt.UseMySql(Configuration.GetConnectionString("NumeneraCypherBookDatabase")));
            services.AddMvc();
            // Create the CORS policy to allow cross-domain accesss
            services.AddCors( opt => 
                opt.AddPolicy("AllowCors", builder => {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                } ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors("AllowCors"); // Apply the CORS policy to the whole api
            app.UseMvc();
        }
    }
}
