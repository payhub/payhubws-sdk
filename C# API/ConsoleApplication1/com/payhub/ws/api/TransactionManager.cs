
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayHubWS.payhub.ws.model;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using PayHubWS.com.payhub.ws.api;
using PayHubWS.com.payhub.ws.model;
using PayHubWS.com.payhub.ws.util;
namespace PayHubWS.payhub.ws.api
{
    ///  @author Agustin Breit 
    /// 
    public class TransactionManager : WsConnections
    {
        private Merchant _merchant;
        public Merchant Merchant { 
                get{return this._merchant;} 
                set{
                    if(value!=null){
                        this._merchant=value;
                        }  
                    } 
        }
        private string _url;
        public string Url{ 
                get{return this._url;} 
                set{
                    if(value!=null){
                        this._url=value;
                        }  
                    } 
        }
        private string _oauthToken;
        public string oauthToken { 
                get{return this._oauthToken;} 
                set{
                    if(value!=null){
                        this._oauthToken=value;
                        }  
                    } 
        }

        public TransactionManager(string url,string token,Merchant m){
            this._url = url;
            this._oauthToken = token;
            this._merchant = m;
        }


        public SaleResponseInformation doSale(Sale sale)
        {
            sale.Merchant = _merchant;
            sale._url = _url;
            var request = setHeadersPost(sale._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(sale, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            SaleResponseInformation response = sale.doSale(json, request);

            return response;
        }
        public SaleResponseInformation getSaleInformation(string saleId)
        {
            SaleResponseInformation responseObject = new SaleResponseInformation();
            var url = _url + Sale.SALE_ID_LINK + saleId;
            var request = setHeadersGet(url, this._oauthToken);
            string result = doGet(request);
            responseObject = JsonConvert.DeserializeObject<SaleResponseInformation>(result);
            responseObject.rowData = result;
            return responseObject;
        }

        public AuthorizationResponseInformation doAuthonly(AuthOnly authorization)
        {
            authorization.Merchant = _merchant;
            authorization._url = _url;
            var request = setHeadersPost(authorization._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(authorization, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            AuthorizationResponseInformation response = authorization.authonly(json, request);

            return response;
        }
        public AuthorizationResponseInformation getAuthorizationInformation(string authorizationId)
        {
            AuthorizationResponseInformation responseObject = new AuthorizationResponseInformation();
            var url = _url + AuthOnly.AUTH_ID_LINK + authorizationId;
            var request = setHeadersGet(url, this._oauthToken);
            string result = doGet(request);
            responseObject = JsonConvert.DeserializeObject<AuthorizationResponseInformation>(result);
            responseObject.rowData = result;
            return responseObject;
        }
        public LastCaptureResponseInfromation doCapture(Capture capture)
        {
            capture.Merchant = _merchant;
            capture._url = _url;
            var request = setHeadersPost(capture._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(capture, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            LastCaptureResponseInfromation response = capture.captureData(json, request);

            return response;
        }
        public LastCaptureResponseInfromation getCaptureInformation(string captureId)
        {
            LastCaptureResponseInfromation responseObject = new LastCaptureResponseInfromation();
            var url = _url + Capture.CAPTURE_ID_LINK + captureId;
            var request = setHeadersGet(url, this._oauthToken);
            string result = doGet(request);
            responseObject = JsonConvert.DeserializeObject<LastCaptureResponseInfromation>(result);
            responseObject.rowData = result;
            return responseObject;
        }
        public LastVoidResponseInformation doVoid(VoidTransaction voidData)
        {
            voidData.Merchant = _merchant;
            voidData._url = _url;
            var request = setHeadersPost(voidData._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(voidData, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            LastVoidResponseInformation response = voidData.performVoidTransaction(json, request);

            return response;
        }
        public LastVoidResponseInformation getCaptureInformation(string voidId)
        {
            LastVoidResponseInformation responseObject = new LastVoidResponseInformation();
            var url = _url + VoidTransaction.VOID_ID_LINK + voidId;
            var request = setHeadersGet(url, this._oauthToken);
            string result = doGet(request);
            responseObject = JsonConvert.DeserializeObject<LastVoidResponseInformation>(result);
            responseObject.rowData = result;
            return responseObject;
        }
        public VerifyResponseInformation doVerify(Verify verifyData) {
            verifyData.Merchant = _merchant;
            verifyData._url = _url;
            var request = setHeadersPost(verifyData._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(verifyData, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            VerifyResponseInformation response = verifyData.performVoidTransaction(json, request);
            return response;
        }
        public VerifyResponseInformation getVerifyInformation(string verifyId)
        {
            VerifyResponseInformation responseObject = new VerifyResponseInformation();
            var url = _url + Verify.VERIFY_ID_LINK + verifyId;
            var request = setHeadersGet(url, this._oauthToken);
            string result = doGet(request);
            responseObject = JsonConvert.DeserializeObject<VerifyResponseInformation>(result);
            responseObject.rowData = result;
            return responseObject;
        }
        public RefundInformation doRefund(Refund refundData)
        {
            refundData.Merchant = _merchant;
            refundData._url = _url;
            var request = setHeadersPost(refundData._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(refundData, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            RefundInformation response = refundData.PerformRefund(json, request);
            return response;
        }
        public RefundInformation getRefundInformation(string refundId)
        {
            RefundInformation responseObject = new RefundInformation();
            var url = _url + Refund.REFUND_ID_LINK + refundId;
            var request = setHeadersGet(url, this._oauthToken);
            string result = doGet(request);
            responseObject = JsonConvert.DeserializeObject<RefundInformation>(result);
            responseObject.rowData = result;
            return responseObject;
        }
        public RecurringBillInformation doRecurringBill(RecurringBill recurringBill)
        {
            recurringBill.Merchant = _merchant;
            recurringBill._url = _url;
            var request = setHeadersPost(recurringBill._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(recurringBill, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            RecurringBillInformation response = recurringBill.PerformRecurringBill(json, request);
            return response;
        }
        public RecurringBillInformation getRecurringBillInformation(string refundId)
        {
            RecurringBillInformation responseObject = new RecurringBillInformation();
            var url = _url + RecurringBill.RECURRENT_BILL_ID_LINK + refundId;
            var request = setHeadersGet(url, this._oauthToken);
            string result = doGet(request);
            responseObject = JsonConvert.DeserializeObject<RecurringBillInformation>(result);
            responseObject.rowData = result;
            return responseObject;
        }
        
    }
}
