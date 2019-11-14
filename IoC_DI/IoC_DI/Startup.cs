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

            //configureservice ���������ǲ���˳��ġ�������Ϊ�ܵ��е��м����
            //���̵���񣬸���Щ�м�������ṩ���ߣ������ṩ���ߵ����˳�����޹ؽ�Ҫ��
            //���м���ķ����ǽ���˳��ģ�����һ�����������
            //������֤���---������ݷ�����Ȩ��---......�ȵ�һ��ѷ��񡣣�ͣ���� ��־�ȵ�֮��ģ�
            services.AddControllers();//api��Ŀ�Ļ�ֻ��һ��controller�Ϳ�����
            //services.AddSingleton<UserRepository>();//����ģʽ �ڵ�һ���������֮��ʵ������֮�󶼽������������

            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<Others>();
            #region AutoFac
            //�������ǵĲִ�Խ�����࣬����Խ��Խ�࣬��Ҫע��ľ�Խ��Խ�࣬
            //�ܲ���һ��һ��ע��ɣ����Ǻ������������˵���������autofac
            //�������ذ�װautofac�İ�װ��

            //��һ����ʵ����Autofac����
            //ContainerBuilder container = new ContainerBuilder();
            //ע��������Ҫע��ķ���������
            //container.RegisterType<UserRepository>().As<IUserRepository>();
            //container.RegisterType<Others>();

            //ע��֮ǰ��ע��

            //ʹ��autofac

            //���ķ������ͣ�����IServiceProvider
            //��֮ǰ�����е�û��ע�뵽autofac��������services ��䵽autofac��������
            //container.Populate(services);

            //�������±������ɹ���
            //var build = container.Build();
            #endregion

            //������IoC�����������ӹܣ���ʹ��autofac�����ӹ���������ص���������
            //return new AutofacServiceProvider(build);

            //����3.0֮�����ٰѷ���ֵ��ΪIServiceProvider�ˡ�

            //����ȥprogram�������



        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<Others>();

            //���ڽ��н���
            //����api��ֻ�����ڲִ��ӿڲ㡣���Զ�api������ӵĶ�����
            //ֻ�������irepository

            //�����кܶ�����ִ�����������Ҫһ����builder.RegisterType��
            //����ֱ��ע����������

            //ͨ�����䶯̬�������򼯣��������򼯵�����ע�뵽��������
            //ע�⣡ע���Ӧ���Ƿ���㣬�����ǽӿڲ�
            var basePath = AppContext.BaseDirectory;

            //���AppContext.BaseDirectory �ǻ�ȡ����ǰ��Ŀ����Ը�·��������api������api/
            //֮����path.combine �൱��ioc_di/ioc_di.repository.dll
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
                endpoints.MapControllers();//api��Ŀ�Ļ�ֻ��һ��controller������
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
