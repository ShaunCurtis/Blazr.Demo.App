﻿using Blazr.Demo.Core;
using Microsoft.AspNetCore.Mvc;

namespace Blazr.Demo.WASM.Server
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWeatherForecastDataBroker weatherForecastDataBroker;

        public WeatherForecastController(IWeatherForecastDataBroker weatherForecastDataBroker)
            => this.weatherForecastDataBroker = weatherForecastDataBroker;

        [Route("/api/weatherforecast/list")]
        [HttpGet]
        public async Task<List<WeatherForecast>> GetForecastAsync()
            => await weatherForecastDataBroker.GetWeatherForecastsAsync();

        [Route("/api/weatherforecast/add")]
        [HttpPost]
        public async Task<bool> AddRecordAsync([FromBody] WeatherForecast record)
            => await weatherForecastDataBroker.AddForecastAsync(record);

        [Route("/api/weatherforecast/delete")]
        [HttpPost]
        public async Task<bool> DeleteRecordAsync([FromBody] Guid Id)
            => await weatherForecastDataBroker.DeleteForecastAsync(Id);

    }
}
