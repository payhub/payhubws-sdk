package com.payhub.ws.api;
import java.io.IOException;
import java.net.HttpURLConnection;

import org.omg.CORBA.Any;
import org.omg.CORBA.Object;
import org.omg.CORBA.TypeCode;
import org.omg.CORBA.portable.InputStream;
import org.omg.CORBA.portable.OutputStream;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.core.JsonParseException;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.payhub.ws.model.AuthOnly;
import com.payhub.ws.model.Capture;
import com.payhub.ws.model.Merchant;
import com.payhub.ws.model.RecurringBill;
import com.payhub.ws.model.Refund;
import com.payhub.ws.model.Sale;
import com.payhub.ws.model.Verify;
import com.payhub.ws.model.VoidTransaction;
import com.payhub.ws.util.WsConnections;

@JsonInclude(JsonInclude.Include.NON_NULL) 
public class TransactionManager extends WsConnections{
	private Merchant _merchant;
    private String _url;
    private String _oauthToken;
    
    /**
     * Create a new Transaction Manager for access to the API and perform queries.
     *
     * @param String url: the url that allows you to retrieve information from the API.
     * @param String token: the token that allows you to access the API.
     * @param Merchant merchant: your Merchant information.
     *  
     */
    public TransactionManager(String url,String token,Merchant m){
    	super(token);    	
        this._url = url;
        this._oauthToken = token;
        this._merchant = m;
    }

    /**
     * Perform a new Sale.
     *
     * @param sale object.
     * @return a SaleResponseInformation object. 
     * @see {@link com.payhub.ws.api.SaleResponseInformation}; 
     */
    public SaleResponseInformation doSale(Sale sale) throws IOException 
    { 
        sale.setMerchant(this._merchant);
        sale.setUrl(this._url);
        HttpURLConnection request = setHeadersPost(sale.getUrl(), this.getToken());
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        String json = mapper.writeValueAsString(sale);
        SaleResponseInformation response = sale.doSale(json, request);
        return response;
    }
    /**
     * Perform a new query that retrieves you the Sale Information for a particular Sale.
     *
     * @param String saleId: the ID of a particular Sale transaction.
     * @return a SaleResponseInformation object. 
     * @see {@link com.payhub.ws.api.SaleResponseInformation}; 
     */
    public SaleResponseInformation getSaleInformation(String saleId) throws IOException
    {
        SaleResponseInformation responseObject = new SaleResponseInformation();
        String url = _url + Sale.SALE_ID_LINK + saleId;
        HttpURLConnection request = setHeadersGet(url, this._oauthToken);
        String result = doGet(request);
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        responseObject =  mapper.readValue(result, SaleResponseInformation.class);
        responseObject.setRowData(result);
        return responseObject;
    }
    /**
     * Perform a new Authorization.
     *
     * @param authorization object.
     * @return a AuthorizationResponseInformation object. 
     * @see {@link com.payhub.ws.api.AuthorizationResponseInformation}; 
     */
    public AuthorizationResponseInformation doAuthonly(AuthOnly authorization) throws IOException
    {
    	authorization.setMerchant(this._merchant);
    	authorization.setUrl(this._url);
        HttpURLConnection request = setHeadersPost(authorization.getUrl(), this.getToken());
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        String json = mapper.writeValueAsString(authorization);
        AuthorizationResponseInformation response = authorization.authOnly(json, request);
        return response;
    }
    /**
     * Perform a new query that retrieves you the Authorization Information for a particular Authorization.
     *
     * @param String authorizationId: the ID of a particular AuthorizationOnly transaction.
     * @return a AuthorizationResponseInformation object. 
     * @see {@link com.payhub.ws.api.AuthorizationResponseInformation}; 
     */
    public AuthorizationResponseInformation getAuthorizationInformation(String authorizationId) throws IOException
    {
    	AuthorizationResponseInformation responseObject = new AuthorizationResponseInformation();
        String url = _url + AuthOnly.AUTH_ID_LINK+ authorizationId;
        HttpURLConnection request = setHeadersGet(url, this._oauthToken);
        String result = doGet(request);
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        responseObject =  mapper.readValue(result, AuthorizationResponseInformation.class);
        responseObject.setRowData(result);
        return responseObject;        
    }
    /**
     * Perform a new CaptureResponse.
     *
     * @param capture object.
     * @return a LastCaptureResponseInformation object. 
     * @see {@link com.payhub.ws.api.LastCaptureResponseInformation}; 
     */
    public LastCaptureResponseInformation doCapture(Capture capture) throws IOException
    {
        capture.setMerchant(this._merchant);
        capture.setUrl(this._url);
        HttpURLConnection request = setHeadersPost(capture.getUrl(), this.getToken());
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        String json = mapper.writeValueAsString(capture);
        LastCaptureResponseInformation response = capture.captureData(json, request);
        return response;
    }
    /**
     * Perform a new query that retrieves you the Capture Information for a particular Capture.
     *
     * @param String captureId: the ID of a particular Capture.
     * @return a LastCaptureResponseInformation object. 
     * @see {@link com.payhub.ws.api.LastCaptureResponseInformation}; 
     */
    public LastCaptureResponseInformation getCaptureInformation(String captureId) throws IOException
    {
        
    	LastCaptureResponseInformation responseObject = new LastCaptureResponseInformation();
        String url = _url + Capture.CAPTURE_ID_LINK+ captureId;
        HttpURLConnection request = setHeadersGet(url, this._oauthToken);
        String result = doGet(request);
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        responseObject =  mapper.readValue(result, LastCaptureResponseInformation.class);
        responseObject.setRowData(result);
        return responseObject;   
        
    }
    /**
     * Perform a new Void Transaction.
     *
     * @param VoidTransaction object.
     * @return a LastVoidResponseInformation object.
     * @see {@link com.payhub.ws.api.LastVoidResponseInformation};  
     */
    public LastVoidResponseInformation doVoid(VoidTransaction voidData) throws IOException
    {
    	voidData.setMerchant(this._merchant);
    	voidData.setUrl(this._url);
        HttpURLConnection request = setHeadersPost(voidData.getUrl(), this.getToken());
        ObjectMapper mapper = new ObjectMapper();
        String json = mapper.writeValueAsString(voidData);
        LastVoidResponseInformation response = voidData.performVoidTransaction(json, request);
        return response;
    }
    /**
     * Perform a new query that retrieves you the Void Information for a particular Void Transaction.
     *
     * @param String voidId: the ID of a particular Void Transaction.
     * @return a LastVoidResponseInformation object. 
     * @see {@link com.payhub.ws.api.LastVoidResponseInformation}; 
     */
    public LastVoidResponseInformation getVoidInformation(String voidId) throws IOException
    {
        LastVoidResponseInformation responseObject = new LastVoidResponseInformation();
        String url = _url + VoidTransaction.VOID_ID_LINK+ voidId;
        HttpURLConnection request = setHeadersGet(url, this._oauthToken);
        String result = doGet(request);
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        responseObject =  mapper.readValue(result, LastVoidResponseInformation.class);
        responseObject.setRowData(result);
        return responseObject;    
    }
    /**
     * Perform a new Verify.
     *
     * @param Verify object.
     * @return a VerfyResponseInformation object.
     * @see {@link com.payhub.ws.api.VerfyResponseInformation}; 
     */
    public VerfyResponseInformation doVerify(Verify verifyData) throws IOException {
    	verifyData.setMerchant(this._merchant);
    	verifyData.setUrl(this._url);
        HttpURLConnection request = setHeadersPost(verifyData.getUrl(), this.getToken());
        ObjectMapper mapper = new ObjectMapper();
        String json = mapper.writeValueAsString(verifyData);
        VerfyResponseInformation response = verifyData.performVerifyTransaction(json, request);
        return response;
    }
    /**
     * Perform a new query that retrieves you the Verify Information for a particular Verify Transaction.
     *
     * @param String verifyId: the ID of a particular Verify Transaction.
     * @return a VerfyResponseInformation object. 
     * @see {@link com.payhub.ws.api.VerfyResponseInformation};
     */
    public VerfyResponseInformation getVerifyInformation(String verifyId) throws JsonProcessingException, IOException, Throwable
    {
    	VerfyResponseInformation responseObject = new VerfyResponseInformation();
        String url = _url + Verify.VERIFY_ID_LINK+ verifyId;
        HttpURLConnection request = setHeadersGet(url, this._oauthToken);
        String result = doGet(request);
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        responseObject =  mapper.readValue(result, VerfyResponseInformation.class);
        responseObject.setRowData(result);
        return responseObject;        
    }
    /**
     * Perform a new Refund.
     *
     * @param Refund object.
     * @return a RefundInformation object. 
     * @see {@link com.payhub.ws.api.RefundInformation};
     */
    public RefundInformation doRefund(Refund refundData) throws IOException
    {
	   refundData.setMerchant(this._merchant);
	   refundData.setUrl(this._url);
  		HttpURLConnection request = setHeadersPost(refundData.getUrl(), this.getToken());
  		ObjectMapper mapper = new ObjectMapper();
  		String json = mapper.writeValueAsString(refundData);
  		RefundInformation response = refundData.PerformRefund(json, request);
  		return response;
    }
    /**
     * Perform a new query that retrieves you the Refund Information for a particular Refund Operation.
     *
     * @param String refundId: the ID of a particular Refund Transaction.
     * @return a RefundInformation object. 
     * @see {@link com.payhub.ws.api.RefundInformation};
     */
    public RefundInformation getRefundInformation(String refundId) throws JsonParseException, JsonMappingException, IOException
    {    	
    	RefundInformation responseObject = new RefundInformation();
        String url = _url + Refund.REFUND_ID_LINK+ refundId;
        HttpURLConnection request = setHeadersGet(url, this._oauthToken);
        String result = doGet(request);
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        responseObject =  mapper.readValue(result, RefundInformation.class);
        responseObject.setRowData(result);
        return responseObject;         
    }
    /**
     * Perform a new RecurringBilling.
     *
     * @param RecurringBill object.
     * @return a RecurringBillingInformation object. 
     * @see {@link com.payhub.ws.api.RecurringBillingInformation};
     */
    public RecurringBillingInformation doRecurringBill(RecurringBill recurringBill) throws IOException
    {
	   	recurringBill.setMerchant(this._merchant);
	   	recurringBill.setUrl(this._url);
   		HttpURLConnection request = setHeadersPost(recurringBill.getUrl(), this.getToken());
   		ObjectMapper mapper = new ObjectMapper();
   		String json = mapper.writeValueAsString(recurringBill);
   		RecurringBillingInformation response = recurringBill.PerformRecurringBill(json, request);
   		return response;
    }
    /**
     * Perform a new query that retrieves you the Recurring Bill Information for a particular Recurring Bill transaction.
     *
     * @param String recurringBillId: the ID of a particular Recurring Bill Transaction.
     * @return a RecurringBillingInformation object. 
     * @see {@link com.payhub.ws.api.RecurringBillingInformation};
     */
    public RecurringBillingInformation getRecurringBillInformation(String recurringBillId) throws IOException
    {
    	RecurringBillingInformation responseObject = new RecurringBillingInformation();
        String url = _url + RecurringBill.RECURRENT_BILL_ID_LINK+ recurringBillId;
        HttpURLConnection request = setHeadersGet(url, this._oauthToken);
        String result = doGet(request);
        ObjectMapper mapper = new ObjectMapper();
        mapper.disable(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES);
        responseObject =  mapper.readValue(result, RecurringBillingInformation.class);
        responseObject.setRowData(result);
        return responseObject;  
        
    }
    public void addMetaData(String metadata,OperationType type,String operationId) throws IOException{
        String metadataUrl=null;
        if(OperationType.Sale.equals(type)){
        	metadataUrl=this._url+"metadata/forSale/"+operationId;
        }if(OperationType.AuthOnly.equals(type)){
        	metadataUrl=this._url+"metadata/forAuthOnly/"+operationId;
        }if(OperationType.Capture.equals(type)){
        	metadataUrl=this._url+"metadata/forCapture/"+operationId;
        }if(OperationType.Bill.equals(type)){
        	metadataUrl=this._url+"metadata/forBill/"+operationId;
        }if(OperationType.CardData.equals(type)){
        	metadataUrl=this._url+"metadata/forCardData/"+operationId;
        }if(OperationType.Customer.equals(type)){
        	metadataUrl=this._url+"metadata/forCustomer/"+operationId;
        }if(OperationType.Merchant.equals(type)){
        	metadataUrl=this._url+"metadata/forMerchant/"+operationId;
        }if(OperationType.RecurringBill.equals(type)){
        	metadataUrl=this._url+"metadata/forRecurringBill/"+operationId;
        }if(OperationType.Schedule.equals(type)){
        	metadataUrl=this._url+"metadata/forSchedule/"+operationId;
        }if(OperationType.Refund.equals(type)){
        	metadataUrl=this._url+"metadata/forRefund/"+operationId;
        }if(OperationType.VoidTransaction.equals(type)){
        	metadataUrl=this._url+"metadata/forVoid/"+operationId;
        }
        HttpURLConnection request = setHeadersPut(metadataUrl, this.getToken());
        String result = doPut(request,metadata);//revisar el codigo del doPut porque con postman el json funciona y aca no
        if(!result.equals("")){
        	System.out.println(result);
        	
        }else{
        	System.out.println("Metadata added successfully");	
        }
        
    }

	
}
