using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.model
{
    [DataContract]
    public class VerifyResponse
    {
        [DataMember]
        private string verifyId;
        [DataMember]
        private string approvalCode;
        [DataMember]
        private string processedDateTime;
        [DataMember]
        private string avsResultCode;
        [DataMember]
        private string verificationResultCode;
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
        private string saleDateTime;
        [DataMember]
        private string tokenizedCard;
        [DataMember]
        private CustomerReference customerReference;
    }
}
