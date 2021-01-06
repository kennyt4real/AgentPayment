using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentPayment.Model
{
    public class AgentPaymentDetail
    {
        public string Id { get; set; }
        public string State { get; set; }
        public string EmailAddress { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public string AccountNumber { get; set; }
        public string AmountDue { get; set; }
        public string PaymentBalanceStatus { get; set; }
    }
}
