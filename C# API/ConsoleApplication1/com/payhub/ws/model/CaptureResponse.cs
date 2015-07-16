using PayHubWS.payhub.ws.model;
using PayHubWS.com.payhub.ws.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.model
{
    [DataContract]
    public class CaptureResponse
    {
        [DataMember]
        private string batchId;
        [DataMember]
        private string transactionId;
        [DataMember]
        private BillingReferences billingReferences;        
    }
}
