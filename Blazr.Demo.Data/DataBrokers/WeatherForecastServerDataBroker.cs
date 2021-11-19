/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

using Blazr.Demo.Core.DataClasses;
using Blazr.Demo.Core.Interfaces;
using Blazr.Demo.Data.DataStores;

namespace Blazr.Demo.Data.DataBrokers
{
    /// <summary>
    /// This is the server version of the data broker.
    /// It's used in the Server SPA and in the API web server for the WASM SPA 
    /// </summary>
    public class WeatherForecastServerDataBroker : IWeatherForecastDataBroker
    {
        private readonly WeatherForecastDataStore weatherForecastDataStore;

        public WeatherForecastServerDataBroker(WeatherForecastDataStore weatherForecastDataStore)
            => this.weatherForecastDataStore = weatherForecastDataStore;

        public async ValueTask<bool> AddForecastAsync(WeatherForecast record)
            => await weatherForecastDataStore!.AddForecastAsync(record);

        public async ValueTask<bool> DeleteForecastAsync(Guid Id)
            => await weatherForecastDataStore!.DeleteForecastAsync(Id);

        public async ValueTask<List<WeatherForecast>> GetWeatherForecastsAsync()
            => await weatherForecastDataStore!.GetWeatherForecastsAsync();

    }
}
