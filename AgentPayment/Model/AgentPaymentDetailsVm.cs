using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentPayment.Model
{
    public class AgentPaymentDetailsVm
    {
        public List<AgentPaymentDetail> AgentPaymentDetails { get; set; }
        public decimal TotalDuePayment
        {
            get
            {
                if (AgentPaymentDetails != null && AgentPaymentDetails.Any())
                {
                    var duePayment = 0m;
                    foreach (var item in AgentPaymentDetails)
                    {
                        if (string.IsNullOrEmpty(item.Status) && string.IsNullOrEmpty(item.PaymentBalanceStatus))
                            duePayment += Convert.ToDecimal(item.AmountDue);
                    }
                    return Math.Round(duePayment, 2);
                }
                return 0.00m;
            }
        }
        public bool AlreadyAcceptedTerms { get; set; }

    }
}
