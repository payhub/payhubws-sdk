using PayHubWS.com.payhub.ws.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.api
{   
    [DataContract]
    public class LastVoidResponseInformation
    {
        private Object metadata;
        [DataMember(Name = "metaData")]
        public Object Metadata
        {
            get { return this.metadata.ToString(); }
            set
            {
                if (value != null)
                    this.metadata = value.ToString();
            }
        }
            [DataMember]
            public string transaction_id;
            public string TransactionId
            {
                get { return this.transaction_id; }
                set
                {
                    if (value != null)
                    {
                        this.transaction_id = value;
                    }
                }
            }
            [DataMember]
            public VoidResponse lastVoidResponse;
            [DataMember]
            public string merchantOrganizationId;
            [DataMember]
            public Object _links;
            [DataMember]
            public List<Errors> errors;
            public string rowData { get; set; }
        }
    
}
