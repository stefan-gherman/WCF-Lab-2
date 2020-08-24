using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
            new Uri(ConfigurationManager.AppSettings["baseAddress"]),
            new Uri(ConfigurationManager.AppSettings["tcpBaseAddress"]));
            host.AddServiceEndpoint(
            typeof(MathTypes.IMath),
            new BasicHttpBinding(),
            "math");
            //NetTcpBinding binding = new NetTcpBinding();
            //binding.Security.Mode = SecurityMode.Message;
            //binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            //binding.Security.Transport.ProtectionLevel =
            //System.Net.Security.ProtectionLevel.EncryptAndSign;
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new TextMessageEncodingBindingElement());
            binding.Elements.Add(new TcpTransportBindingElement());
            host.AddServiceEndpoint(
            typeof(MathTypes.IMath),
            binding,
            "math");
            ServiceMetadataBehavior meta = new ServiceMetadataBehavior();
            meta.HttpGetEnabled = true;
            host.Description.Behaviors.Add(meta);
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