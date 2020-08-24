﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
            MathTypes.IMath channel = new ChannelFactory<MathTypes.IMath>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8080/math")).CreateChannel();
            response = channel.Add(mreq);
            Console.WriteLine("Call via BasicProfileBinding: {0}",
            response.response.result);
            Console.ReadKey(true);
        }
    }
}