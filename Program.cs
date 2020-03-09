using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

            using (var context = new BankContext())
            {
                // I wipe out my database at each execution
                context.Database.EnsureDeleted();
                // Then I recreate it
                context.Database.EnsureCreated();

                var person = new Person
                {
                    Name = "M. Richard"
                };

                person.Accounts = new List<SavingsAccount>
                {
                    new SavingsAccount { Amount = 2000000.00, Periodicity = 1, SavingsRate = 0.05 },
                    new SavingsAccount { Amount = 250000.00, Periodicity = 12, SavingsRate = 0.15 },
                    new SavingsAccount { Amount = 10000000.00, Periodicity = 12, SavingsRate = 0.02 }
                };

                context.Add(person);
                // After the shop is added, his relatonships will too
                // if they are defined          
                context.SaveChanges();
                // Once changes are added, they must be saved to the database
                // unless you will have an unexisting one        
                double amountSaved = SavingCalculator.CalculateTotalSaved(DateTime.Now, DateTime.Now.AddYears(1));
                MessageBox.Show( "Total = " + amountSaved, "Total Amount Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
    }
}
