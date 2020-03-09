using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace WindowsFormsApp2
{
    class BankContext : DbContext // DbContext overriden
        {
            // Product entites can be accessed by this context
            public virtual DbSet<Person> Persons { get; set; }
            // Shop entities can be accessed by this context
            public virtual DbSet<SavingsAccount> SavingsAccounts { get; set; }

            // OnConfiguring is a hook that executes while the context configures itself
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // I add a connection to a database instance while the context configures
                optionsBuilder.UseSqlServer(
                    @"Server=LOCALHOST\SQLEXPRESS;Database=Bank20200309;Integrated Security=True");
            }
        }

}
