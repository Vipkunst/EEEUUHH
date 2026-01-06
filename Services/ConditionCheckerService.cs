using Microsoft.Extensions.Caching.Memory;

namespace EEEUUHH.Services
{
    public class ConditionCheckerService: BackgroundService
    {
        private readonly IMemoryCache _data;

        public ConditionCheckerService(IMemoryCache data)
        {
            _data = data;
        }

        double humidityThreshold = 200;

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _data.TryGetValue("gas", out var gas);
                _data.TryGetValue("humidity", out var humidity);
                _data.TryGetValue("temperature", out var temperature);

                if (humidity != null && Convert.ToDouble(humidity) < humidityThreshold)
                {
                    // Send Signal to Arduino to turn on Pump
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
