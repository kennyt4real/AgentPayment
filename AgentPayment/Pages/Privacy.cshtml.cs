using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AgentPayment.Context;
using AgentPayment.Model;
using AgentPayment.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AgentPayment.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly PaymentDbContext _context;
        private readonly ILogger<PrivacyModel> _logger;
        public AgentPaymentDetailsVm AgentPaymentDetailsVm = new AgentPaymentDetailsVm();

        public PrivacyModel(PaymentDbContext context, ILogger<PrivacyModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet(string agentEmail)
        {
            var agentForPayment = _context.AgentDueForPayment.FirstOrDefaultAsync(x => x.Email.Trim().ToLower().Equals(agentEmail.Trim().ToLower())).Result;
           
            if (!string.IsNullOrEmpty(agentEmail))
            {

                var agentPaymentList = Startup.AgentPaymentDetails.Where(x=>x.EmailAddress.Equals(agentEmail)).ToList();
                if (agentPaymentList.Any())
                {
                    if (agentForPayment != null)
                        AgentPaymentDetailsVm.AlreadyAcceptedTerms = agentForPayment.AcceptedTerms;
                    AgentPaymentDetailsVm.AgentPaymentDetails = agentPaymentList;
                }
            }
        }
        public void OnPost(string agentEmail, string agentAccountNumber)
        {
            try
            {
                var agentForPayment = _context.AgentDueForPayment.FirstOrDefaultAsync(x => x.Email.Trim().ToLower().Equals(agentEmail.Trim().ToLower())).Result;
                if (agentForPayment == null)
                {
                    var agentDueForPayment = new AgentDueForPayment { Email = agentEmail, AccountNumber = agentAccountNumber, AcceptedTerms = true };

                    _context.AgentDueForPayment.Add(agentDueForPayment);
                    _context.SaveChanges();
                    AgentPaymentDetailsVm.AgentPaymentDetails = Startup.AgentPaymentDetails.Where(x => x.EmailAddress.Trim().ToLower().Equals(agentEmail.Trim().ToLower())).ToList();
                    AgentPaymentDetailsVm.AlreadyAcceptedTerms = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
