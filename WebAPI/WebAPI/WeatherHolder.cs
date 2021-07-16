using System.Collections.Generic;
using System.Linq;
using System;

namespace WebAPI
{
    public class WeatherHolder
    {
        public List<WeatherForecast> ListWeathers { get; set; }

        public readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        public WeatherHolder()
        {
            int countData = 3; 
            Random rng = new Random();
            ListWeathers = Enumerable.Range(1, countData).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();
        }

        public void AddData(DateTime date, int temperatureC, string summary)
        {
            ListWeathers.Add(new WeatherForecast { Date = date, TemperatureC = temperatureC, Summary = summary });
        }

        public List<WeatherForecast> ShowData(DateTime dateStart, DateTime dateFinish)
        {
            List<WeatherForecast> newListWeathers = new List<WeatherForecast>();

            foreach (WeatherForecast item in ListWeathers)
            {
                if (item.Date >= dateStart && item.Date <= dateFinish)
                {
                    newListWeathers.Add(item);
                }
            }
            return newListWeathers;
        }

        public bool ChangeData(DateTime date, int temperature)
        {
            for (int i = 0; i < ListWeathers.Count; i++)
            {
                if (ListWeathers[i].Date.Date == date.Date)
                {
                    ListWeathers[i].TemperatureC = temperature;
                    return true;
                }
            }
            return false;
        }

        public bool DeleteDate(DateTime date)
        {
            for (int i = 0; i < ListWeathers.Count; i++)
            {
                if (ListWeathers[i].Date.Date == date.Date)
                {
                    ListWeathers.Remove(ListWeathers[i]);
                    return true;
                }
            }
            return false;
        }
    }
}