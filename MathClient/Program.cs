using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MathClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MathTypes.MathRequest req = new MathTypes.MathRequest(23, 44);
            MathTypes.MathRequestMessage mreq = new MathTypes.MathRequestMessage();
            mreq.request = req;
            mreq.CustomHeader = 8;
            MathTypes.MathResponseMessage response;
            //NetTcpBinding binding = new NetTcpBinding();
            //binding.Security.Mode = SecurityMode.Message;
            //binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            //binding.Security.Transport.ProtectionLevel =
            //System.Net.Security.ProtectionLevel.EncryptAndSign;
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new TextMessageEncodingBindingElement());
            binding.Elements.Add(new TcpTransportBindingElement());
            MathTypes.IMath channel = new ChannelFactory<MathTypes.IMath>(
                binding,
                new EndpointAddress("net.tcp://localhost:8081/math")).CreateChannel();
            response = channel.Add(mreq);
            Console.WriteLine("Call via BasicProfileBinding: {0}",
            response.response.result);
            Console.ReadKey(true);
        }
    }
}