import java.io.IOException;
import java.math.BigDecimal;
import java.text.ParseException;

import Samples.AuthOnlyAndCaptureSample;
import Samples.RecurringBillingSample;
import Samples.RefundSample;
import Samples.SaleAndVoidSample;
import Samples.VerifySample;

import com.payhub.ws.api.SaleResponseInformation;
import com.payhub.ws.api.TransactionManager;
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
        saleAndVoidSample.doSale();
        AuthOnlyAndCaptureSample authOnlyAndCaptureSample = new AuthOnlyAndCaptureSample();
        authOnlyAndCaptureSample.doAuthorization();        
        Samples.RecurringBillingSample recurringBillingSample =  new RecurringBillingSample();
        recurringBillingSample.doRecurringBilling();
        RefundSample refundSample =  new RefundSample();
        refundSample.doRefund();
        VerifySample verifySample = new VerifySample();
        verifySample.doVerify();
	}

}
