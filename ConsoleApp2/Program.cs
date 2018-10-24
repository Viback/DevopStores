using System;
using System.Net;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient myWebClient = new WebClient();
            string siteSource = myWebClient.DownloadString("https://devopstoresapp.herokuapp.com/api/stores");

            if (siteSource.Contains("storeId")&& siteSource.Contains("storeName") && siteSource.Contains("address") && siteSource.Contains("zipCode") && siteSource.Contains("phoneNo"))
            {
                Console.WriteLine("Stores api working as intended.");
            }
            else
            {
                Console.WriteLine("Error in stores api.");
            }
            WebClient myWebClient1 = new WebClient();
            string siteSource1 = myWebClient1.DownloadString("https://devopstoresapp.herokuapp.com/api/inventories/stores");

            if (siteSource1.Contains("storeId") && siteSource1.Contains("prodId") && siteSource1.Contains("qty"))
            {
                Console.WriteLine("Inventories api working as intended.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Error in inventories api.");
                Console.ReadLine();
            }
        }
    }
}
