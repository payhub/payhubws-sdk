using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.model
{
    [DataContract]
    public class RefundResponse
    {
        [DataMember]
        private string saleTransactionId;
        [DataMember]
        private string refundTransactionId;
        [DataMember]
        private string token;
    }
}
