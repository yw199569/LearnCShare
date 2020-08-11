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
        //中间件是必须的，中间件就是处理http请求和响应
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //判断当前开发环境
            if (env.IsDevelopment())
            {
                //显示开发异常页面中间件
                app.UseDeveloperExceptionPage();
            }
            byte[] testa = new byte[20];
            testa.Append(Convert.ToByte('a'));
            app.Use(async (context, next) =>
            {
                context.Response.WriteaSync()
                 context.Response.Redirect("https://www.baidu.com");//在下一个中间件之前执行的
                await next();
                context.Response.Redirect("https://www.qq.com");//在下一个中间件之后执行的
            });


            app.UseHttpsRedirection();
            //终结点(断点) 路由中间件
            app.UseRouting();

            app.UseAuthorization();
            //终结点中间件，这里是配置中间件和路由之间的关系，映射
            //必须和路由中间件配合使用
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
                
            });
        }
    }
}
