using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HW_InlineConstraints.Controllers
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
        [Route("{id:int}")]
        //https://localhost:5001/weatherforecast/3546
        //https://localhost:5001/weatherforecast/123456789
        public IEnumerable<WeatherForecast> Get(int id)
        {
            var rng = new Random();
            return Enumerable.Range(1, id).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }

        [HttpGet]
        [Route("{id:bool}")]
        //https://localhost:5001/weatherforecast/true
        //https://localhost:5001/weatherforecast/false
        public IEnumerable<WeatherForecast> GetWeatherForecast()
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
        [Route("{day:datetime}")]
        //https://localhost:5001/weatherforecast/2017-12-30
        //https://localhost:5001/weatherforecast/2021-10-01
        public IEnumerable<WeatherForecast> Get(DateTime day)
        {
            var curDay = ((int)day.DayOfWeek) + 1;
            var rng = new Random();
            return Enumerable.Range(1, curDay).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }

        [HttpGet]
        [Route("{dec:decimal}")]
        //https://localhost:5001/weatherforecast/5.55
        //https://localhost:5001/weatherforecast/49.99
        public IEnumerable<WeatherForecast> Get(decimal dec)
        {
            var decNumber = ((int)dec);
            var rng = new Random();
            return Enumerable.Range(1, decNumber).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }

        [HttpGet]
        [Route("{dou:double}")]
        //https://localhost:5001/weatherforecast/-1,001.01e8
        //https://localhost:5001/weatherforecast/1,001.01e8
        public IEnumerable<WeatherForecast> Get(double dou)
        {
            var douNumber = ((int)(dou % 10) + 2);
            var rng = new Random();
            return Enumerable.Range(1, douNumber).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }

        [HttpGet]
        [Route("{len:length(10)}")]
        //https://localhost:5001/weatherforecast/indexindex
        //https://localhost:5001/weatherforecast/ifsomebody
        public IEnumerable<WeatherForecast> Get(string len)
        {
            int lenNumber = len.Length;
            var rng = new Random();
            return Enumerable.Range(1, lenNumber).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }

        [HttpGet]
        [Route("{name:length(15, 20)}")]
        //https://localhost:5001/weatherforecast/indexindexindex
        //https://localhost:5001/weatherforecast/hellofromnamelength
        public IEnumerable<WeatherForecast> Get(string name, int i = 2)
        {
            int nameLength = name.Length;
            var rng = new Random();
            return Enumerable.Range(i, nameLength).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }

        [HttpGet]
        [Route("{phone:regex(^\\d{{3}}-\\d{{3}}-\\d{{4}}$)}")]
        //https://localhost:5001/weatherforecast/indexindexindex
        //https://localhost:5001/weatherforecast/hellofromnamelength
        public IEnumerable<WeatherForecast> Get(int j = 20, int i = 2)
        {
            var rng = new Random();
            return Enumerable.Range(i, j).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }
    }
}
