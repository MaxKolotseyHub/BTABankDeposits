using BTABankDeposits.Controllers;
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
        public DbSet<Client> Cliens { get; set; }
    }
}