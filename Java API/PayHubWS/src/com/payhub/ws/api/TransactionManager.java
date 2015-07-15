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
    
    public TransactionManager(String url,String token,Merchant m){
    	super(token);    	
        this._url = url;
        this._oauthToken = token;
        this._merchant = m;
    }


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
    public VerfyResponseInformation doVerify(Verify verifyData) throws IOException {
    	verifyData.setMerchant(this._merchant);
    	verifyData.setUrl(this._url);
        HttpURLConnection request = setHeadersPost(verifyData.getUrl(), this.getToken());
        ObjectMapper mapper = new ObjectMapper();
        String json = mapper.writeValueAsString(verifyData);
        VerfyResponseInformation response = verifyData.performVerifyTransaction(json, request);
        return response;
    }
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
}
