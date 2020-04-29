using BTABankDeposits.Controllers;
using BTABankDeposits.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Db
{
    public class MyDbContext:DbContext
    {
        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(new MyDbContextInitializer());
        }
        public MyDbContext(string conntectionString = "Default"):base(conntectionString)
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(p => p.BirthDate)
                .HasColumnType("datetime2");
            modelBuilder.Entity<Client>()
                .Property(p => p.PassportCreatedDate)
                .HasColumnType("datetime2");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DepositType> DepositTypes { get; set; }
        public DbSet<AccountNumber> AccountNumbers{ get; set; }
    }
}