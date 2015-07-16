using PayHubWS.payhub.ws.model;
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
    public class SaleResponseInformation
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
        private SaleResponse saleResponse;
        public SaleResponse SaleResponse {
            get { return this.saleResponse; }
            set
            {
                if (value != null)
                    this.saleResponse = value;    
            }
        }
        [DataMember]
        public Object _links;

        [DataMember]
        public List<Errors> errors;
        public string rowData { get; set; }
        
    }
}
