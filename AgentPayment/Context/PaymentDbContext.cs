using AgentPayment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentPayment.Context
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
             : base(options)
        {
        }
        public DbSet<AgentDueForPayment> AgentDueForPayment { get; set; }
    }
}
