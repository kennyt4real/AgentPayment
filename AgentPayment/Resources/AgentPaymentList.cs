using AgentPayment.Model;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AgentPayment.Resources
{
    public static class AgentPaymentList 
    {
        public static List<AgentPaymentDetail> GetAgentPaymentDetail()
        {

            var paymentList = new List<AgentPaymentDetail>();
            string fileName =Environment.CurrentDirectory + @"\wwwroot\AGENTS PAYMENT FOR TECH TEAM.xlsx";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using var reader = ExcelReaderFactory.CreateReader(stream);
                var count = 0;
                while (reader.Read()) //Each row of the file
                {
                    count += 1;
                    paymentList.Add(new AgentPaymentDetail
                    {
                        Id = "MOB" + "-" + count.ToString().PadLeft(4, '0'),
                        State = reader.GetValue(0)?.ToString() ?? string.Empty,
                        EmailAddress = reader.GetValue(1)?.ToString() ?? string.Empty,
                        Status = reader.GetValue(2)?.ToString() ?? string.Empty,
                        Name = reader.GetValue(3)?.ToString() ?? string.Empty,
                        Bank = reader.GetValue(4)?.ToString() ?? string.Empty,
                        AccountNumber = reader.GetValue(5)?.ToString() ?? string.Empty,
                        AmountDue = reader.GetValue(6)?.ToString() ?? string.Empty,
                        PaymentBalanceStatus = reader.GetValue(7)?.ToString() ?? string.Empty

                    });
                }
            }
           
            return paymentList;

        }
    }
}
