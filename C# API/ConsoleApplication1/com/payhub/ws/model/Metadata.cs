using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayHubWS.com.payhub.ws.model;
using System.Runtime.Serialization;

namespace PayHubWS.com.payhub.ws.api
{
    ///  @author Agustin Breit 
    /// 
    [DataContract]
    public class Metadata
    {        
        private Order order;
        [DataMember(Name="Order")]
        public Order Order
        {
            get { return this.order; }
            set
            {
                if (value != null)
                    this.order = value;
            }
        }
    }
}
