using PayHubWS.com.payhub.ws.model;
using PayHubWS.payhub.ws.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.api
{
    [DataContract]
    public class RefundInformation
    {
        private Metadata metadata;
        [DataMember(Name = "metadata")]
        public Metadata Metadata
        {
            get { return this.metadata; }
            set
            {
                if (value != null)
                    this.metadata = value;
            }
        }
        [DataMember]
        private Merchant merchant;
        public Merchant Merchant
        {
            get { return this.merchant; }
            set
            {
                if (value != null)
                {
                    this.merchant = value;
                }
            }
        }
        [DataMember]
        private string transaction_id;
        [DataMember]
        private RefundResponse lastRefundResponse;
        [DataMember]
        private string merchantOrganizationId;
        [DataMember]
        public Object _links;

        [DataMember]
        private List<Errors> errors;
        public string rowData { get; set; }
    }
}
