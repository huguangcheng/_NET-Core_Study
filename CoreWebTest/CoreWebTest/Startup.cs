using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreWebTest
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
            //多例式transient   每次请求都是实例化的一个全新的对象。
            services.AddTransient<IService,MyService>();
            //每次请求，范围式。每次请求进来，都会判断是否是同一个httpcontext，
            //第一次请求，它会IA a=new A（）；并将其缓存下来
            //之后的请求，若是同一个httpcontext，那么它依然会返回这个a
            //services.AddScoped<IService, MyService>();
            //单例模式  只要皇帝不死，太子一直是太子！
            //只要服务器不嗝屁，请求获取的对象一直是a
            //services.AddSingleton<IService, MyService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseMiddleware<RequestSetOptionMiddleware>();
            //上面这个中间件，我们仿照微软的来写，比如app.UseXXX();

            app.UseRequestSetOption();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
