using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using IoC_DI.IRepository;
//using IoC_DI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using System.IO;

namespace IoC_DI
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

            //configureservice 服务的添加是不分顺序的。它是在为管道中的中间件的
            //做铺垫服务，给这些中间件服务提供工具，所以提供工具的这个顺序是无关紧要的
            //而中间件的服务是讲究顺序的，比如一个请求过来了
            //大门验证身份---根据身份发放授权卡---......等等一大堆服务。（停车场 日志等等之类的）
            services.AddControllers();//api项目的话只用一个controller就可以了
            //services.AddSingleton<UserRepository>();//单例模式 在第一次请求服务之后实例化，之后都将沿用这个对象

            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<Others>();
            #region AutoFac
            //假如我们的仓储越来愈多，服务越来越多，需要注入的就越来越多，
            //总不能一个一个注入吧，于是乎，我们引入了第三方容器autofac
            //首先下载安装autofac的安装包

            //第一步，实例化Autofac容器
            //ContainerBuilder container = new ContainerBuilder();
            //注册容器需要注入的服务类或组件
            //container.RegisterType<UserRepository>().As<IUserRepository>();
            //container.RegisterType<Others>();

            //注释之前的注入

            //使用autofac

            //更改返回类型，返回IServiceProvider
            //将之前的所有的没有注入到autofac容器当中services 填充到autofac容器当中
            //container.Populate(services);

            //容器重新编译生成构建
            //var build = container.Build();
            #endregion

            //最终让IoC第三方容器接管，即使用autofac容器接管替代，返回第三方容器
            //return new AutofacServiceProvider(build);

            //现在3.0之后不让再把返回值改为IServiceProvider了。

            //首先去program里面添加



        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<Others>();

            //现在进行解耦
            //现在api层只依赖于仓储接口层。所以对api层所添加的东西，
            //只引用这个irepository

            //假如有很多这个仓储服务，那岂不是要一个个builder.RegisterType？
            //下面直接注入整个程序集

            //通过反射动态创建程序集，并将程序集的类型注入到容器当中
            //注意！注入的应该是服务层，而不是接口层
            var basePath = AppContext.BaseDirectory;

            //这个AppContext.BaseDirectory 是获取到当前项目的相对根路径，就是api层下面api/
            //之后用path.combine 相当于ioc_di/ioc_di.repository.dll
            builder.RegisterAssemblyTypes(Assembly.LoadFrom
                (Path.Combine(basePath,"IoC_DI.Repository.dll")))
                .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(Assembly.Load("IoC_DI.Repository")).AsImplementedInterfaces();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name:"",
                //    pattern:""
                //    );
                endpoints.MapControllers();//api项目的话只用一个controller就行了
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
