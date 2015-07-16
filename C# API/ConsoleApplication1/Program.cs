
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
using PayHubWS.Samples;


namespace PayHubWS
{
    class Program
    {
        static void Main(string[] args)
        {
            MetadataSample metadata = new MetadataSample();
            metadata.addMetadata();

           // SaleAndVoidSample sale = new SaleAndVoidSample();
           //// sale.doSale();
           // sale.getInformation();
           // AuthOnlyAndCaptureSample authOnly = new AuthOnlyAndCaptureSample();
           // authOnly.doAuthorization();
           // RecurringBillingSample recurringBilling = new RecurringBillingSample();
           // recurringBilling.doRecurringBilling();
           // RefundSample refundSample = new RefundSample();
           // refundSample.doRefund();
           // VerifySample verifySample = new VerifySample();
           // verifySample.doVerify();
           
        }
    }
}
