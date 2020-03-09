using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class SavingCalculator
    {
        public static double CalculateTotalSaved(DateTime begin, DateTime end)
        {
            TimeSpan datediff = end - begin;
            int nbMonth = Convert.ToInt32(Math.Floor(datediff.TotalDays / 30));
            List<SavingsAccount> Accounts;
            double totalAmount = 0.0;
            using (var context = new BankContext())
            {
                Accounts = context.SavingsAccounts.ToList();
            }
            foreach(SavingsAccount account in Accounts)
            {
                totalAmount += (account.Amount * account.SavingsRate) * (nbMonth / account.Periodicity);
            }
            return totalAmount;
        }

    }
}
