﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ProductShop.models;

namespace ProductShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var db = new ProductShopContext();
            db.Database.EnsureCreated();
        }

        
        public IConfiguration Configuration { get; }
        // public DatabaseFacade DatabaseFacade { get; set; }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(
                c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "ProductShop", Version = "v1"}); });

            
            services.AddDbContext<ProductShopContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration.GetConnectionString("ProductDbContextConnection"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductShop v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}