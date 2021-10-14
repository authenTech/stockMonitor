using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Service.StockService
{
    public class StockMonitorService : IStockMonitorService
    {
        public void Monitor()
        {
            string stockUrl = _configuration.GetSection("StockSite").Value;
        }
    }
}
