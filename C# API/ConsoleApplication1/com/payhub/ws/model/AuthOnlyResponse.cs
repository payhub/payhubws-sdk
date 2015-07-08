using PayHubWS.payhub.ws.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.model
{   
    ///  @author Agustin Breit 
    /// 
    [DataContract]
    public class AuthOnlyResponse
    {
        [DataMember]
        private string transactionId;
        public string TransactionId
        {
            get { return this.transactionId; }
            set
            {
                if (value != null)
                {
                    this.transactionId = value;
                }
            }
        }
        [DataMember]
        private string approvalCode;
        [DataMember]
        private string processedDateTime;
        [DataMember]
        private string avsResultCode;
        [DataMember]
        private string verificationResultCode;
        [DataMember]
        private string batchId;
        [DataMember]
        private string responseCode;
        [DataMember]
        private string responseText;
        [DataMember]
        private string cisNote;
        [DataMember]
        private string riskStatusResponseText;
        [DataMember]
        private string riskStatusRespondeCode;
        [DataMember]
        private string dateTime;
        [DataMember]
        private string tokenizedCard;
        [DataMember]
        private BillingReferences billingReferences;
        [DataMember]
        private CustomerReference customerReference;
    }
}
