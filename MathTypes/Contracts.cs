using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MathTypes
{
    [DataContract(Namespace = "http://example.org/math/types")]
    public class MathRequest
    {
        [DataMember]
        public double x;

        [DataMember]
        public double y;

        public MathRequest(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [DataContract(Namespace = "http://example.org/math/types")]
    public class MathResponse
    {
        [DataMember]
        public double result;

        public MathResponse(double result)

        {
            this.result = result;
        }
    }

    [MessageContract]
    public class MathRequestMessage
    {
        [MessageHeader]
        public int CustomHeader;

        [MessageBodyMember]
        public MathRequest request;
    }

    [MessageContract]
    public class MathResponseMessage
    {
        [MessageBodyMember]
        public MathResponse response;
    }

    [ServiceContract(Namespace = "http://example.org/math/contracts")]
    public interface IMath
    {
        [OperationContract]
        MathResponseMessage Add(MathRequestMessage req);

        [OperationContract]
        MathResponseMessage Subtract(MathRequestMessage req);

        [OperationContract]
        MathResponseMessage Multiply(MathRequestMessage req);

        [OperationContract]
        MathResponseMessage Divide(MathRequestMessage req);
    }
}