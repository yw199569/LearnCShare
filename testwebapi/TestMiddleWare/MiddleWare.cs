using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace testwebapi.TestMiddleWare
{
    public class MiddleWare
    {
        private readonly RequestDelegate _next;

        public MiddleWare(RequestDelegate nest)
        {
            _next = nest;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //管道会自动调用这个方法
            //在这里写中间件的业务代码
            httpContext.Response.WriteAsync("Hello");


            await _next(httpContext);//在这里调用下一个中间件
        }
    }
}
