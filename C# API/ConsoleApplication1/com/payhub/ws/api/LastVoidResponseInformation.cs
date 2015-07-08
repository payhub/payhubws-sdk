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
            private string transaction_id;
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
            private VoidResponse lastVoidResponse;
            [DataMember]
            private string merchantOrganizationId;
            [DataMember]
            public Object _links;
            [DataMember]
            private List<Errors> errors;
            public string rowData { get; set; }
        }
    
}
