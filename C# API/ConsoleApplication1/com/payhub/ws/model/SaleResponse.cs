using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayHubWS.com.payhub.ws.model;

namespace PayHubWS.payhub.ws.model
{
    ///  @author Agustin Breit 
    /// 
    [DataContract]
	public class SaleResponse
	{
		private static readonly long serialVersionUID = 1L;
        [DataMember]
		private string saleId;
        public string SaleId {
            get { return saleId; }
            set { if (value != null)saleId = value; }
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
		private string saleDateTime;
        [DataMember]
		private string tokenizedCard;
        [DataMember]
		private BillingReferences billingReferences;
        [DataMember]
		private CustomerReference customerReference;

	}

}

