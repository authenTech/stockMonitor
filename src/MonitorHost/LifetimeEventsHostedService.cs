using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorHost
{
    public class LifetimeEventsHostedService : IHostedService
    {
        private Timer _timer;
        private int _invokeCount = 0;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CallEvery30Minutes, null, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(30));

            return Task.CompletedTask;
            // throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void CallEvery30Minutes(object state)
        {
            _invokeCount++;
                
            if (_invokeCount == 3)
            {
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
    }
}
