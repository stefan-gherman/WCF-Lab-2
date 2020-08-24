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
        public MathResponse Add(MathRequest req)
        {
            return new MathResponse(req.x + req.y);
        }

        public MathResponse Divide(MathRequest req)
        {
            return new MathResponse(req.x / req.y);
        }

        public MathResponse Multiply(MathRequest req)
        {
            return new MathResponse(req.x * req.y);
        }

        public MathResponse Subtract(MathRequest req)
        {
            return new MathResponse(req.x - req.y);
        }
    }
}