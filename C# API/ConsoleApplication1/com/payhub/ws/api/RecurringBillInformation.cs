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
    public class RecurringBillInformation
    {
        [DataMember]
        private Metadata metaData;
        [DataMember]
        private RecurringBillResponse lastRecurringBillResponse;         
        [DataMember]
        public Object _links;

        [DataMember]
        private List<Errors> errors;
        public string rowData { get; set; }
    }
}
