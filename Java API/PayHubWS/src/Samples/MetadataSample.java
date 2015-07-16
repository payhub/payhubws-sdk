package Samples;

import java.io.IOException;

import com.payhub.ws.api.OperationType;
import com.payhub.ws.api.TransactionManager;
import com.payhub.ws.model.Merchant;

public class MetadataSample {
	public void addMetadata() throws IOException{
		String url = "https://staging-api.payhub.com/api/v2/";
        String oauth = "107d74ab-4a18-4713-88ff-69bd05710086";
        Merchant merchant = new Merchant();
        merchant.organization_id = 10127;
        merchant.terminal_id = 215;	
		TransactionManager transaction = new TransactionManager(url, oauth, merchant);
	    String datos = "{\"order\": {\"id\": 465, \"invoice\":\"MyIncoice\", \"lines\": [{\"City\": \"Cordoba\"}, {\"Neighborhood\": \"Nueva Cordoba\"}]}}";
	    transaction.addMetaData(datos, OperationType.AuthOnly, "182522");
	}
}
