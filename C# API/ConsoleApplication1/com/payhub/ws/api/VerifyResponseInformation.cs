using PayHubWS.com.payhub.ws.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.api
{   [DataContract]
    public class VerifyResponseInformation
    {
        [DataMember]
        private Metadata metadata;
        [DataMember]
        private VerifyResponse verifyResponse;
        [DataMember]
        public Object _links;

        [DataMember]
        private List<Errors> errors;
        public string rowData { get; set; }
    }
}
