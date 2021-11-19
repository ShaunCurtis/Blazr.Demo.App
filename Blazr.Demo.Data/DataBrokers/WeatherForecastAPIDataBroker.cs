/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

using Blazr.Demo.Core.DataClasses;
using Blazr.Demo.Core.Interfaces;
using System.Net.Http.Json;

namespace Blazr.Demo.Data.DataBrokers
{
    /// <summary>
    /// This is the client version of the data broker.
    /// It's used in the Wasm SPA and gets its data from the API 
    /// </summary>
    public class WeatherForecastAPIDataBroker : IWeatherForecastDataBroker
    {
        private readonly HttpClient? httpClient;

        public WeatherForecastAPIDataBroker(HttpClient httpClient)
            => this.httpClient = httpClient!;

        public async ValueTask<bool> AddForecastAsync(WeatherForecast record)
        {
            var response = await httpClient!.PostAsJsonAsync($"/api/weatherforecast/add", record);
            var result = await response.Content.ReadFromJsonAsync<bool>();
            return result;
        }

        public async ValueTask<bool> DeleteForecastAsync(Guid Id)
        {
            var response = await httpClient!.PostAsJsonAsync($"/api/weatherforecast/delete", Id);
            var result = await response.Content.ReadFromJsonAsync<bool>();
            return result;
        }

        public async ValueTask<List<WeatherForecast>> GetWeatherForecastsAsync()
        {
            var list = await httpClient!.GetFromJsonAsync<List<WeatherForecast>>($"/api/weatherforecast/list");
            return list!;
        }
    }
}
