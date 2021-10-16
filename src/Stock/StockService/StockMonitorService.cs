using System;
using System.Collections.Generic;
using System.Text;
using Monitor.Host.MonitorHost;



namespace Stock.Service.StockService
{
    public class StockMonitorService : LifetimeEventsHostedServices, IStockMonitorService
    {
        public void Monitor()
        {
            string stockUrl = _configuration.GetSection("StockSite").Value;
        }
    }
}
