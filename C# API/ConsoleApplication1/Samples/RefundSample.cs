using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayHubWS.payhub.ws.model;
using System.Globalization;
using PayHubWS.com.payhub.ws.api;
using PayHubWS.com.payhub.ws.model;
using PayHubWS.payhub.ws.api;

namespace PayHubWS.Samples
{
    public class RefundSample
    {
        public void doRefund(){
            string url = "https://staging-api.payhub.com/api/v2/";
            string oauth = "107d74ab-4a18-4713-88ff-69bd05710086";

            Merchant merchant = new Merchant();
            merchant.organization_id = 10127;
            merchant.terminal_id = 215;
            var transaction_id="182363";
            var record_format="CREDIT_CARD";
            Refund refund = new Refund(merchant, transaction_id, record_format);
            TransactionManager transaction = new TransactionManager(url, oauth, merchant);
            RefundInformation response = transaction.doRefund(refund);
            Console.Write(response.rowData);
        }
    }
}
