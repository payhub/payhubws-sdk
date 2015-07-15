
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
    /// <summary> 
    /// Create a new Transaction Manager for access to the API and perform queries.
    ///
    /// <param name="url"> 
    /// String url: the url that allows you to retrieve information from the API.
    /// </param>
    /// <param name="token"> 
    /// String token: the token that allows you to access the API.
    /// </param>
    /// <param name="merchant"> 
    /// Merchant merchant: your Merchant information.
    /// </param>  
    /// </summary> 
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

        /// <summary> 
        /// Perform a new Sale.
        ///
        /// <param name="sale"> 
        /// Sale Object
        /// </param>
        /// <returns>
        /// SaleResponseInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.SaleResponseInformation"/>
        /// </summary> 
        public SaleResponseInformation doSale(Sale sale)
        {
            sale.Merchant = _merchant;
            sale._url = _url;
            var request = setHeadersPost(sale._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(sale, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            SaleResponseInformation response = sale.doSale(json, request);

            return response;
        }
        /// <summary> 
        /// Perform a new query that retrieves you the Sale Information for a particular Sale Transaction.
        ///
        /// <param name="saleId"> 
        /// the ID of a particular Sale Transaction.
        /// </param>
        /// <returns>
        /// SaleResponseInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.SaleResponseInformation"/>
        /// </summary> 
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
        /// <summary> 
        /// Perform a new AuthOnly.
        ///
        /// <param name="authorization"> 
        /// AuthOnly Object
        /// </param>
        /// <returns>
        /// AuthorizationResponseInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.AuthorizationResponseInformation"/>
        /// </summary> 
        public AuthorizationResponseInformation doAuthonly(AuthOnly authorization)
        {
            authorization.Merchant = _merchant;
            authorization._url = _url;
            var request = setHeadersPost(authorization._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(authorization, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            AuthorizationResponseInformation response = authorization.authonly(json, request);

            return response;
        }
        /// <summary> 
        /// Perform a new query that retrieves you the AuthorizationOnly Information for a particular AuthorizationOnly Transaction.
        ///
        /// <param name="authorizationId"> 
        /// the ID of a particular AuthorizationOnly Transaction.
        /// </param>
        /// <returns>
        /// AuthorizationResponseInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.AuthorizationResponseInformation"/>
        /// </summary> 
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
        /// <summary> 
        /// Perform a new Capture.
        ///
        /// <param name="capture"> 
        /// Capture Object
        /// </param>
        /// <returns>
        /// LastCaptureResponseInfromation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.LastCaptureResponseInfromation"/>
        /// </summary> 
        public LastCaptureResponseInfromation doCapture(Capture capture)
        {
            capture.Merchant = _merchant;
            capture._url = _url;
            var request = setHeadersPost(capture._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(capture, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            LastCaptureResponseInfromation response = capture.captureData(json, request);

            return response;
        }
        /// <summary> 
        /// Perform a new query that retrieves you the Capture Information for a particular Capture Transaction.
        ///
        /// <param name="captureId"> 
        /// the ID of a particular Capture Transaction.
        /// </param>
        /// <returns>
        /// LastCaptureResponseInfromation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.LastCaptureResponseInfromation"/>
        /// </summary> 
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
        /// <summary> 
        /// Perform a new VoidTransaction.
        ///
        /// <param name="voidData"> 
        /// VoidTransaction Object
        /// </param>
        /// <returns>
        /// LastVoidResponseInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.LastVoidResponseInformation"/>
        /// </summary> 
        public LastVoidResponseInformation doVoid(VoidTransaction voidData)
        {
            voidData.Merchant = _merchant;
            voidData._url = _url;
            var request = setHeadersPost(voidData._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(voidData, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            LastVoidResponseInformation response = voidData.performVoidTransaction(json, request);

            return response;
        }
        /// <summary> 
        /// Perform a new query that retrieves you the Void Information for a particular Void Transaction.
        ///
        /// <param name="voidId"> 
        /// the ID of a particular Void Transaction.
        /// </param>
        /// <returns>
        /// LastVoidResponseInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.LastVoidResponseInformation"/>
        /// </summary> 
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
        /// <summary> 
        /// Perform a new Verify.
        /// <param name="verifyData"> 
        /// Verify Object
        /// </param>
        /// <returns>
        /// VerifyResponseInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.VerifyResponseInformation"/>
        /// </summary> 
        public VerifyResponseInformation doVerify(Verify verifyData) {
            verifyData.Merchant = _merchant;
            verifyData._url = _url;
            var request = setHeadersPost(verifyData._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(verifyData, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            VerifyResponseInformation response = verifyData.performVoidTransaction(json, request);
            return response;
        }
        /// <summary> 
        /// Perform a new query that retrieves you the Verify Information for a particular Verify Transaction.
        ///
        /// <param name="verifyId"> 
        /// the ID of a particular Verify Transaction.
        /// </param>
        /// <returns>
        /// VerifyResponseInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.VerifyResponseInformation"/>
        /// </summary> 
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
        /// <summary> 
        /// Perform a new Refund.
        ///
        /// <param name="refundData"> 
        /// Refund Object
        /// </param>
        /// <returns>
        /// RefundInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.RefundInformation"/>
        /// </summary> 
        public RefundInformation doRefund(Refund refundData)
        {
            refundData.Merchant = _merchant;
            refundData._url = _url;
            var request = setHeadersPost(refundData._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(refundData, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            RefundInformation response = refundData.PerformRefund(json, request);
            return response;
        }
        /// <summary> 
        /// Perform a new query that retrieves you the Refund Information for a particular Refund Operation.
        ///
        /// <param name="refundId"> 
        /// the ID of a particular Refund Transaction.
        /// </param>
        /// <returns>
        /// RefundInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.RecurringBillingInformation"/>
        /// </summary> 
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
        /// <summary> 
        /// Perform a new RecurringBilling.
        ///
        /// <param name="recurringBill"> 
        /// RecurringBill object.
        /// </param>
        /// <returns>
        /// RecurringBillingInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.RecurringBillingInformation"/>
        /// </summary> 
        public RecurringBillInformation doRecurringBill(RecurringBill recurringBill)
        {
            recurringBill.Merchant = _merchant;
            recurringBill._url = _url;
            var request = setHeadersPost(recurringBill._url, this._oauthToken);
            string json = JsonConvert.SerializeObject(recurringBill, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            RecurringBillInformation response = recurringBill.PerformRecurringBill(json, request);
            return response;
        }
        /// <summary> 
        /// Perform a new query that retrieves you the Recurring Bill Information for a particular Recurring Bill transaction.
        ///
        /// <param name="recurringBillId"> 
        /// String recurringBillId: the ID of a particular Recurring Bill Transaction.
        /// </param>
        /// <returns>
        /// a RecurringBillingInformation object.
        /// </returns>   
        /// <seealso cref="PayHubWS.com.payhub.ws.api.RecurringBillingInformation"/>
        /// </summary> 
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
