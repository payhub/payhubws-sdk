﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.api
{
    public enum OperationType
    {
        Sale,//forSale
        AuthOnly,//forAuthOnly
        Capture,//forCapture
        Bill,//forBill
        CardData,//forCardData
        Customer,//forCustomer
        Merchant,//forMerchant
        RecurringBill,//forRecurringBill
        Schedule,//forSchedule
        Refund,//forRefund
        VoidTransaction,//forVoid
    }
}
