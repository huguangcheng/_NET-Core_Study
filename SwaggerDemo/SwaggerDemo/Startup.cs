using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace SwaggerDemo
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
            #region---------Swagger---------
            services.AddSwaggerGen(options=> {
                options.SwaggerDoc("v1",new OpenApiInfo
                {
                    Version="v1.1.0",
                    Title="Web API",
                    Description="这是API接口文档",
                    Contact=new OpenApiContact { Name="Maste_king",Email="215931921@qq.com" }
                });
                //为  swagger json and  ui设置xml文档注释路径
                var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);
                var xmlPath = Path.Combine(basePath, "SwaggerDemo.xml");
                options.IncludeXmlComments(xmlPath);
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region--------Swagger-----------
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Help");
            });
            #endregion
            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
