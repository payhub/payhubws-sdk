using System;
using System.Numerics;

using System.Runtime.Serialization;

namespace PayHubWS.payhub.ws.model
{
    ///  @author Agustin Breit 
    /// 
	public abstract class AbstractBill 
	{
		protected static readonly long serialVersionUID = 2865435483666149222L;

        protected string note { get; set; }

        protected string po_number { get; set; }

        protected string invoice_number { get; set; }

        protected long customerId { get; set; }

        protected long customerCardId { get; set; }

        protected TransactionAmount tax_amount { get; set; }

        protected decimal base_amount {get;set;}

		private BillingReferences billingReferences;

        protected decimal totalAmount{get;set;}

        protected decimal shipping_amount { get; set; }
        


	}

}

