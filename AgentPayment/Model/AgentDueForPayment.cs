using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentPayment.Model
{
    public class AgentDueForPayment
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public bool AcceptedTerms { get; set; }
    }
}
