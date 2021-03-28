using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/")]
     
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
        public string api(string x, string y)        {
            ResultData r = new ResultData();
            try
            {
                
                int result = Convert.ToInt32(x) % Convert.ToInt32(y);
                // Cannot set the key to "string" as it's a reserved key
                r.expression = $"{x}%{y}";
                r.answer = $"{result}";
                r.error=false;
                
                
            }
            catch (Exception ex)
            {
                r.expression = $"{x}%{y}";
                r.error=true;
            }
            return JsonConvert.SerializeObject(r);

        }
    }
}
