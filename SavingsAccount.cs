using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class SavingsAccount
    {
        public Guid SavingsAccountId {get;set;}
        public double Amount { get; set; }
        public double SavingsRate { get; set; }
        public int Periodicity { get; set; }
    }
}
