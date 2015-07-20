import java.io.IOException;
import java.math.BigDecimal;
import java.text.ParseException;

import Samples.AuthOnlyAndCaptureSample;
import Samples.FindTransactionReportsSample;
import Samples.RecurringBillingSample;
import Samples.RefundSample;
import Samples.SaleAndVoidSample;
import Samples.VerifySample;

import com.payhub.ws.api.BillInformation;
import com.payhub.ws.api.SaleResponseInformation;
import com.payhub.ws.api.TransactionManager;
import com.payhub.ws.api.TransactionType;
import com.payhub.ws.model.Bill;
import com.payhub.ws.model.CardData;
import com.payhub.ws.model.Customer;
import com.payhub.ws.model.Merchant;
import com.payhub.ws.model.Sale;
import com.payhub.ws.model.TransactionAmount;
import com.payhub.ws.model.VoidTransaction;

/**
 * 
 */

/**
 * @author agustin
 *
 */
public class Program {

	/**
	 * @param args
	 * @throws IOException 
	 * @throws ParseException 
	 */
	public static void main(String[] args) throws IOException, ParseException {
		
        SaleAndVoidSample saleAndVoidSample = new SaleAndVoidSample();
        saleAndVoidSample.getInformation();
       // AuthOnlyAndCaptureSample authOnlyAndCaptureSample = new AuthOnlyAndCaptureSample();
       // authOnlyAndCaptureSample.doAuthorization();        
      //  Samples.RecurringBillingSample recurringBillingSample =  new RecurringBillingSample();
      //  recurringBillingSample.doRecurringBilling();
      //  RefundSample refundSample =  new RefundSample();
      //  refundSample.doRefund();
      //  VerifySample verifySample = new VerifySample();
      //  verifySample.doVerify();
		
	/*	 String url = "https://staging-api.payhub.com/api/v2/";
         String oauth = "107d74ab-4a18-4713-88ff-69bd05710086";
         Merchant merchant = new Merchant();
         merchant.organization_id = 10127;
         merchant.terminal_id = 215;
         TransactionManager transaction = new TransactionManager(url, oauth, merchant);
         BillInformation bill = new BillInformation(transaction);
         bill.getDataByTransaction(TransactionType.Sale, "182347");
         bill.getBill();
         System.out.println(bill);
         */
		
	/*	FindTransactionReportsSample trp = new FindTransactionReportsSample();
		trp.findTransactions();*/
	}

}
