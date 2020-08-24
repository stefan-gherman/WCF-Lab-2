using MathTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceHost
{
    public class MathService : MathTypes.IMath

    {
        public MathResponseMessage Add(MathRequestMessage req)
        {
            Console.WriteLine("Custom header value {0}", req.CustomHeader);
            MathTypes.MathResponseMessage resp = new MathTypes.MathResponseMessage();
            resp.response = new MathResponse(req.request.x + req.request.y);
            return resp;
        }

        public MathResponseMessage Divide(MathRequestMessage req)
        {
            Console.WriteLine("Custom header value {0}", req.CustomHeader);
            MathTypes.MathResponseMessage resp = new MathTypes.MathResponseMessage();
            resp.response = new MathResponse(req.request.x / req.request.y);
            return resp;
        }

        public MathResponseMessage Multiply(MathRequestMessage req)
        {
            Console.WriteLine("Custom header value {0}", req.CustomHeader);
            MathTypes.MathResponseMessage resp = new MathTypes.MathResponseMessage();
            resp.response = new MathResponse(req.request.x * req.request.y);
            return resp;
        }

        public MathResponseMessage Subtract(MathRequestMessage req)
        {
            Console.WriteLine("Custom header value {0}", req.CustomHeader);
            MathTypes.MathResponseMessage resp = new MathTypes.MathResponseMessage();
            resp.response = new MathResponse(req.request.x - req.request.y);
            return resp;
        }
    }
}