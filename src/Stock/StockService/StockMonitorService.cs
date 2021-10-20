using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using HtmlAgilityPack;




namespace Stock.Service.StockService
{
    public class StockMonitorService : IStockMonitorService
    {
        private readonly IConfiguration _configuration;

        public StockMonitorService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Monitor()
        {
            string stockUrl = _configuration.GetSection("StockSite").Value;
            string stockName = _configuration.GetSection("StockName").Value;
            string stockValue = _configuration.GetSection("StockValue").Value;
            string[] stockQuotes = _configuration.GetSection("StockQuotes").Get<string[]>();

            HtmlWeb htmlWeb = new HtmlWeb();

            foreach (string quote in stockQuotes)
            {
                string htmlLoad = string.Format(stockUrl, quote, quote);

                HtmlDocument htmlDocument = htmlWeb.Load(htmlLoad);

                HtmlNodeCollection htmlNodes = htmlDocument.DocumentNode.SelectNodes(stockName);
                string stockName2 = htmlNodes[0].InnerText;


                htmlNodes = htmlDocument.DocumentNode.SelectNodes(stockValue);
                string stockValue2 = htmlNodes[0].InnerText;
                Console.WriteLine($"{stockName2} ${stockValue2}");

            }
        }
    }
}
