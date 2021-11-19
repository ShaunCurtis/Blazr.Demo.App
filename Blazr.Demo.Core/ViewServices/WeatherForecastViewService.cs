using Blazr.Demo.Core.DataClasses;
using Blazr.Demo.Core.Interfaces;
/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.Demo.Core.ViewServices
{
    public class WeatherForecastViewService
    {
        private readonly IWeatherForecastDataBroker? weatherForecastDataBroker;

        public List<WeatherForecast>? Records { get; private set; }

        public WeatherForecastViewService(IWeatherForecastDataBroker weatherForecastDataBroker)
            => this.weatherForecastDataBroker = weatherForecastDataBroker!;

        public async ValueTask GetForecastsAsync()
        {
            Records = null;
            NotifyListChanged(Records, EventArgs.Empty);
            Records = await weatherForecastDataBroker!.GetWeatherForecastsAsync();
            NotifyListChanged(Records, EventArgs.Empty);
        }

        public async ValueTask AddRecord(WeatherForecast record)
        {
            await weatherForecastDataBroker!.AddForecastAsync(record);
            await GetForecastsAsync();
        }

        public async ValueTask DeleteRecord(Guid Id)
        {
            _ = await weatherForecastDataBroker!.DeleteForecastAsync(Id);
            await GetForecastsAsync();
        }

        public event EventHandler<EventArgs>? ListChanged;

        public void NotifyListChanged(object? sender, EventArgs e)
            => ListChanged?.Invoke(sender, e);
    }
}
