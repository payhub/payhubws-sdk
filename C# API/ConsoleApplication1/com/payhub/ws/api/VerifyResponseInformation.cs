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
        private VerifyResponse verifyResponse;
        public VerifyResponse _verifyResponse
        {
            get { return this.verifyResponse; }
            set
            {
                if (value != null)
                    this.verifyResponse = value;
            }
        }
        [DataMember]
        public Object _links;

        [DataMember]
        public List<Errors> errors;
        public string rowData { get; set; }
    }
}
