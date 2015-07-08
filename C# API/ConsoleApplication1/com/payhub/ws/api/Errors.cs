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
    class Errors
    {
        [DataMember]
        private string status;
        [DataMember]
        private string code;
        [DataMember]
        private string location;
        [DataMember]
        private string reason;
        [DataMember]
        private string severity;
    }
}
