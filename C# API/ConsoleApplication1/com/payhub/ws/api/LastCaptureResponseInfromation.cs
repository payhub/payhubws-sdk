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
    public class LastCaptureResponseInfromation
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
        public CaptureResponse lastCaptureResponse { get; set; }
         [DataMember]
         public Object _links { get; set; }
         [DataMember]
         public List<Errors> errors { get; set; }
        public string rowData { get; set; }
    }
}
