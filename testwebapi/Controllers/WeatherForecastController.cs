using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testwebapi.Service;
namespace testwebapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("Write")]
        public IEnumerable<string> Write()
        {
        //     var build = new ContainerBuilder();
        //     build.RegisterType<OutPutNowDate>().As<IOutPutNowDate>();
        //     //build.RegisterType<IOutput>().As<ConsoleOutPut>();
        //     _container=build.Build();
        //     // Create the scope, resolve your IDateWriter,
        //     // use it, then dispose of the scope.
        //   var aaa=  _container.Resolve<IOutPutNowDate>();
           // aaa.WriteDate();
            return null;
        }

        public static void aaa()
        {
            // using (var scope = _container.BeginLifetimeScope())
            // {
            //     var writer = scope.Resolve<IOutPutNowDate>();
            //     writer.WriteDate();
            // }

        }
    }

   
}
