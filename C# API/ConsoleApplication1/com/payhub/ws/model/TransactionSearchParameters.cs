using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayHubWS.com.payhub.ws.model
{
    public class TransactionSearchParameters
    {
        private string batchIdFrom;
        private string batchIdTo;
        private string transactionType;
        private string responseCode;
        private string amountFrom;
        private string amountTo;
        private string firstName;
        private string lastName;
        private string trnDateFrom;
        private string trnDateTo;
        private string cardType;
        private string cardLast4Digits;
        private string cardToken;
        private string authAmountFrom;
        private string authAmountTo;
        private string swiped;
        private string source;
        private string phoneNumber;
        private string email;
        private string note;
        private string transactionStatus;

        public string BatchIdFrom { get { return this.batchIdFrom; } set { this.batchIdFrom = value; } }
        public string BatchIdTo { get { return this.batchIdTo; } set { this.batchIdTo = value; } }
        public string TransactionType { get { return this.transactionType; } set { this.transactionType = value; } }
        public string ResponseCode { get { return this.responseCode; } set { this.responseCode = value; } }
        public string AmountFrom { get { return this.amountFrom; } set { this.amountFrom = value; } }
        public string AmountTo { get { return this.amountTo; } set { this.amountTo = value; } }
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }
        public string TrnDateFrom { get { return this.trnDateFrom; } set { this.trnDateFrom = value; } }
        public string TrnDateTo { get { return this.trnDateTo; } set { this.trnDateTo = value; } }  
     
        public string CardType { get { return this.cardType; } set { this.cardType = value; } }
        public string CardLast4Digits { get { return this.cardLast4Digits; } set { this.cardLast4Digits = value; } }
        public string CardToken { get { return this.cardToken; } set { this.cardToken = value; } }
        public string AuthAmountFrom { get { return this.authAmountFrom; } set { this.authAmountFrom = value; } }
        public string AuthAmountTo { get { return this.authAmountTo; } set { this.authAmountTo = value; } }
        public string Swiped { get { return this.swiped; } set { this.swiped = value; } }
        public string Source { get { return this.source; } set { this.source = value; } }
        public string PhoneNumber { get { return this.phoneNumber; } set { this.phoneNumber = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
        public string Note { get { return this.note; } set { this.note = value; } }
        public string TransactionStatus { get { return this.transactionStatus; } set { this.transactionStatus = value; } }
        
    }
}
