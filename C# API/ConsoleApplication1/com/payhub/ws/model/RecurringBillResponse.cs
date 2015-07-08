using PayHubWS.payhub.ws.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.model
{
    [DataContract]
    public class RecurringBillResponse
    {
        [DataMember]
        private string recurringBillId;
        [DataMember]
        private CustomerReference customerReference;
        [DataMember]
        private BillingReferences billingReferences;
    }
}
