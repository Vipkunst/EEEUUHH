using Microsoft.Extensions.Caching.Memory;

namespace PiGrow.Services
{
    public class ConditionCheckerService: BackgroundService
    {
        private readonly IMemoryCache _data;
        private readonly ILogger<ConditionCheckerService> _logger;

        public ConditionCheckerService(IMemoryCache data, ILogger logger)
        {
            _data = data;
        }

        double humidityThreshold = 200;

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Main loop
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
