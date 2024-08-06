using HighSchoolMarathon.WebApp.Controllers;

namespace HighSchoolMarathon.WebApp.Infrastructure
{
    public class AutoAgentService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public AutoAgentService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Random random = new Random();
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                // Update every 10 seconds
                var nextRunTime = now.AddSeconds(10 + random.Next(20));

                var delay = nextRunTime - now;

                if (delay.TotalMilliseconds > 0)
                {
                    await Task.Delay(delay, stoppingToken);
                }

                using (var scope = _serviceProvider.CreateScope())
                {
                    var notificationController = scope.ServiceProvider.GetRequiredService<AutoAgentController>();
                    await notificationController.SendUpdateNotification(notificationController.Get_runnerRepository());
                }
            }
        }
    }
}
