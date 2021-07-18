using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherHolder _holder;

        public WeatherForecastController(WeatherHolder holder)
        {
            _holder = holder;
        }

        [HttpGet("get")]
        public IEnumerable<WeatherForecast> Get([FromQuery] DateTime dateStart, [FromQuery] DateTime dateFinish)
        {
            if (dateStart == DateTime.MinValue && dateFinish == DateTime.MinValue)
            {
                return _holder.ListWeathers; 
            }
            else
            {
                return _holder.ShowData(dateStart, dateFinish);
            }
        }

        [HttpPost]
        public void Post([FromQuery] DateTime date, [FromQuery] int temperatureC, [FromQuery] string summary)
        {
            _holder.AddData(date, temperatureC, summary);
        }

        [HttpPatch]
        public void Patch([FromQuery] DateTime date, [FromQuery] int temperatureC)
        {
            _holder.ChangeData(date, temperatureC);
        }

        [HttpDelete]
        public void Delete([FromQuery] DateTime date) 
        {
            _holder.DeleteDate(date);
        }

    }
}
