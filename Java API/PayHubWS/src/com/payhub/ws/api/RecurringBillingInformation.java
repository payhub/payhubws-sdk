package com.payhub.ws.api;
import java.io.IOException;
import java.util.List;

import com.payhub.ws.model.RecurringBillResponse;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.core.JsonParseException;
import com.fasterxml.jackson.databind.JsonMappingException;

@JsonInclude(JsonInclude.Include.NON_NULL)  
public class RecurringBillingInformation {
	
	private RecurringBillResponse lastRecurringBillResponse;         
	public Object _links;
	private List<Errors> errors;
	public String rowData;
	private Object metaData;
    private TransactionManager transactionManager;
    private BillInformation billInformation;
    private CardDataInformation cardDataInformation;
    private CustomerInformation customerInformation;
    private MerchantInformation merchantInformation; 
    private ScheduleInformation scheduleInformation;
    
	public String getMetaData() {
		return (String) metaData;
	}
	public void setMetaData(Object metadata) {
		this.metaData = metadata;
	}
	public RecurringBillResponse getLastRecurringBillResponse() {
		return lastRecurringBillResponse;
	}
	public void setLastRecurringBillResponse(
			RecurringBillResponse lastRecurringBillResponse) {
		this.lastRecurringBillResponse = lastRecurringBillResponse;
	}
	public Object get_links() {
		return _links;
	}
	public void set_links(Object _links) {
		this._links = _links;
	}
	public List<Errors> getErrors() {
		return errors;
	}
	public void setErrors(List<Errors> errors) {
		this.errors = errors;
	}
	public String getRowData() {
		return rowData;
	}
	public void setRowData(String rowData) {
		this.rowData = rowData;
	}
	/**
	 * @param transactionManager the transactionManager to set
	 */
	public void setTransactionManager(TransactionManager transactionManager) {
		this.transactionManager = transactionManager;
	}
	/**
	 * @return the billInformation
	 * @throws IOException 
	 * @throws JsonMappingException 
	 * @throws JsonParseException 
	 */
	public BillInformation getBillInformation() throws JsonParseException, JsonMappingException, IOException {
		if(billInformation==null){
			BillInformation b = new BillInformation(this.transactionManager);
			b.setUrl(this.transactionManager.getUrl()+"recurring-bill/");
			b.getBillForRecurringBillInformationByTransactionId(lastRecurringBillResponse.getRecurringBillId());
			billInformation=b;
		}
		return billInformation;
	}
	/**
	 * @return the cardDataInformation
	 * @throws IOException 
	 * @throws JsonMappingException 
	 * @throws JsonParseException 
	 */
	public CardDataInformation getCardDataInformation() throws JsonParseException, JsonMappingException, IOException {
		if(cardDataInformation==null){
			CardDataInformation c = new CardDataInformation(this.transactionManager);
			c.getDataByTransaction(TransactionType.RecurringBill, lastRecurringBillResponse.getRecurringBillId());
			cardDataInformation=c;			
			}
		return cardDataInformation;
	}

	/**
	 * @return the customerInformation
	 * @throws IOException 
	 * @throws JsonMappingException 
	 * @throws JsonParseException 
	 */
	public CustomerInformation getCustomerInformation() throws JsonParseException, JsonMappingException, IOException {
		if(customerInformation==null){
				CustomerInformation c = new CustomerInformation(this.transactionManager);
				c.setUrl(this.transactionManager.getUrl()+"recurring-bill/");
				c.getCustomerForSaleInformationByTransactionId(lastRecurringBillResponse.getRecurringBillId());
				customerInformation=c;				
			}
		return customerInformation; 
	}

	/**
	 * @return the merchantInformation
	 * @throws IOException 
	 * @throws JsonMappingException 
	 * @throws JsonParseException 
	 */
	public MerchantInformation getMerchantInformation() throws JsonParseException, JsonMappingException, IOException {
		if(merchantInformation==null){			
				MerchantInformation m = new MerchantInformation(this.transactionManager);
				m.getDataByTransaction(TransactionType.RecurringBill, lastRecurringBillResponse.getRecurringBillId());
				merchantInformation=m;				
			}
		return merchantInformation;
	}
	/**
	 * @return the scheduleInformation
	 * @throws IOException 
	 * @throws JsonMappingException 
	 * @throws JsonParseException 
	 */
	public ScheduleInformation getScheduleInformation() throws JsonParseException, JsonMappingException, IOException {
		if(merchantInformation==null){			
			ScheduleInformation s = new ScheduleInformation(this.transactionManager);
			s.getDataByTransaction(TransactionType.Schedule, lastRecurringBillResponse.getRecurringBillId());
			scheduleInformation=s;				
		}
		return scheduleInformation;
	}

}
