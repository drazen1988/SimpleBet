using NLog;

namespace SimpleBet.Middleware
{
    public class HostApplicationLifetimeEventsHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public HostApplicationLifetimeEventsHostedService(
            IHostApplicationLifetime hostApplicationLifetime)
            => _hostApplicationLifetime = hostApplicationLifetime;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
            _hostApplicationLifetime.ApplicationStopping.Register(OnStopping);
            _hostApplicationLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        private void OnStarted()
        {
            Logger logger = LogManager.GetLogger("errorLogger");
            logger.Error("OnStarted");
        }

        private void OnStopping()
        {
            Logger logger = LogManager.GetLogger("errorLogger");
            logger.Error("OnStopping");
        }

        private void OnStopped()
        {
            Logger logger = LogManager.GetLogger("errorLogger");
            logger.Error("OnStopped");
        }
    }
}
