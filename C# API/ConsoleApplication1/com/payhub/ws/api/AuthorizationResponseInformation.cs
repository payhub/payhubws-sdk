using PayHubWS.payhub.ws.model;
using PayHubWS.com.payhub.ws.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.api
{
    ///  @author Agustin Breit 
    /// 
    [DataContract]
    public class AuthorizationResponseInformation
    {
        
        private Metadata metadata;
        [DataMember(Name="metadata")]
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
        private AuthOnlyResponse authOnlyResponse;
        public AuthOnlyResponse AuthOnlyResponse
        {
            get { return this.authOnlyResponse; }
            set
            {
                if (value != null)
                    this.authOnlyResponse = value;    
            }
        }
        [DataMember]
        public Object _links;

        [DataMember]
        private List<Errors> errors;
       
        public string rowData { get; set; }
        
    }
}
