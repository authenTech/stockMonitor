using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Stock.Service.StockService;

namespace MonitorHost
{
    public class LifetimeEventsHostedService : IHostedService
    {
        private Timer _timer;
        private int _invokeCount = 0;
        private readonly IConfiguration _configuration;
        private readonly IStockMonitorService _stockMonitorService;
        public LifetimeEventsHostedService(IConfiguration configuration,IStockMonitorService stockMonitorService)
        {
            _configuration = configuration;
            _stockMonitorService = stockMonitorService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            string intervalstring = _configuration.GetSection("CallMonitorInMinutes").Value;
            int intervalInMinutes = int.Parse(intervalstring);
            _timer = new Timer(CallInMinutes, null, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(intervalInMinutes));

            return Task.CompletedTask;
            // throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void CallInMinutes(object state)
        {
            _stockMonitorService.Monitor();
           

            _invokeCount++;

                
            if (_invokeCount == 3)
            {
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
    }
}
