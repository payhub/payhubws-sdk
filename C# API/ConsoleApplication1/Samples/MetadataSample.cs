using PayHubWS.com.payhub.ws.api;
using PayHubWS.payhub.ws.api;
using PayHubWS.payhub.ws.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.Samples
{
    class MetadataSample
    {
        public void addMetadata(){
            string url = "https://staging-api.payhub.com/api/v2/";
            string oauth = "107d74ab-4a18-4713-88ff-69bd05710086";

            Merchant merchant = new Merchant();
            merchant.organization_id = 10127;
            merchant.terminal_id = 215;
		    TransactionManager transaction = new TransactionManager(url, oauth, merchant);
          //  var b = transaction.getAuthorizationInformation("182349");
            var a = transaction.getAllBillForSaleInformation();
	        string datos = "{\"order\": {\"id\": 465, \"invoice\":\"MyIncoice\", \"lines\": [{\"City\": \"Cordoba\"}, {\"Neighborhood\": \"Nueva Cordoba\"}]}}";
            transaction.addMetaData(datos, TransactionType.AuthOnly, "182525");
	    }
    }
}
