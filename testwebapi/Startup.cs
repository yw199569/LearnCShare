using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using testwebapi.Service;

namespace testwebapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //注入依赖服务
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //注入了对控制器和API相关功能的支持
            services.AddControllers();
            //注入了控制器API以及视图的功能支持；
            services.AddControllersWithViews();
            //添加跨域
            services.AddCors();


            //注册自定义服务
            //服务的生命周期
            //注册自定义服务的时候，必须要选择一个生命周期

            //内置的依赖注入的三种生命周期
            //瞬时，每次从服务容器里请求示例时，都会创建一个新的实例
            //添加一个瞬时的依赖注入services.AddTransient<接口，实现>();

            //作用域，线程单例，在同一个线程(请求)里，只实例化一次
            //添加一个作用域的依赖注入services.AddScoped();

            //单例 、全局单例，只有在第一次请求的时候才会出创建一次实例
            //添加一个单例的依赖注入services.AddSingleton();



            //注册一个自定义的服务 
            services.AddSingleton<ISendMsg,SendQQ>();
            //注册一个自定义的依赖服务
            services.AddMessage(a=>a.SendQQ());

        }
        //配置中间件
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
