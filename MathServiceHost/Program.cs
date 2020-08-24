using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(
typeof(MathService),
new Uri(ConfigurationManager.AppSettings["baseAddress"]));
            host.AddServiceEndpoint(
            typeof(MathTypes.IMath),
            new BasicHttpBinding(),
            "math");
            host.Open();
            Console.WriteLine(
            "MathService is listening on the following...");
            foreach (ServiceEndpoint e in host.Description.Endpoints)
            {
                Console.WriteLine("{0} ({1})",
                e.Address.ToString(),
                e.Binding.Name);
            }
            Console.WriteLine("\nPress [Enter] to terminate.");
            Console.ReadLine();
        }
    }
}