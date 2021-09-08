using System;
using HtmlAgilityPack;

namespace GenericHost
{
    class Program
    {
        static void Main(string[] args)
        {

            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return;
            }
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDoc = htmlWeb.Load("https://finance.yahoo.com/quote/SPCE?p=SPCE&.tsrc=fin-srch");


            //Create here

            string[] quotes = new string[3];
            quotes.SetValue("SPCE", 0);
            quotes.SetValue("V", 1);
            quotes.SetValue("MRNA", 2);
            // Creating my list of stocks

            foreach (string quote in quotes)
            {
                string htmlLoad = ($"https://finance.yahoo.com/quote/{quote}?p={quote}&.tsrc=fin-srch");
                HtmlDocument htmlDocument = htmlWeb.Load(htmlLoad);
            
                HtmlNodeCollection htmlNodes = htmlDocument.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div[1]/div/div[2]/div/div/div[5]/div/div/div/div[2]/div[1]/div[1]/h1");
                string stockName = htmlNodes[0].InnerText;
            
               
                htmlNodes = htmlDocument.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div[1]/div/div[2]/div/div/div[5]/div/div/div/div[3]/div[1]/div[1]/span[1]");
                string stockValue = htmlNodes[0].InnerText;
                Console.WriteLine($"{stockName} ${stockValue}");

            }




            // the same results as above, just in a different format
            string[] quotes2 = new string[] {"SPCE", "VISA", "MRNA"};
            foreach (string quote in quotes2)
            {
                string htmlLoad = ($"https://finance.yahoo.com/qupte/{quote}?p={quote}&.tsrc=fin-srch");
                HtmlDocument htmlDocument = htmlWeb.Load(htmlLoad);


            }


            // //*[@id="quote-header-info"]/div[3]/div[1]/div[1]/span[1]




            string stock1 = "SPCE";
            string stock2 = "VISA";
            string htmlLoad1 = ($"https://finance.yahoo.com/qupte/{stock1}?p={stock1}&.tsrc=fin-srch");
            string htmlLoad2 = ($"https://finance.yahoo.com/qupte/{stock2}?p={stock2}&.tsrc=fin-srch");

            HtmlDocument htmlDocument1 = htmlWeb.Load(htmlLoad1);
            HtmlDocument htmlDocument2 = htmlWeb.Load(htmlLoad2);



            Console.WriteLine("Which stock would you like to check today?");
            //This will request a stock symbol from the user

            string s1 = Console.ReadLine();
            Console.WriteLine("{0}", s1);
            string htmlLoad3 = ($"https://finance.yahoo.com/qupte/{s1}?p={s1}&.tsrc=fin-srch");
            HtmlDocument htmlDocument3 = htmlWeb.Load(htmlLoad3);


        }
        public enum quotes
        {
            SPCE,
            VISA,
        }

    }
}
/* 8/10 How would I call 2 or more stocks from finance.yahoo.com
 create a way for the user to request a stock quote
 interpolation or string.format
 create a github.com account
      to put my code into the repositor
    This also becomes my portfolio

8/16 setup dual authenticatoin on github, and retry loading the stockMonitor
 * pass the program to windows and try using Visual studio on Windows
 * text Alex when it works and he will send the next steps
 * download fiddler classic
 */

