using BTABankDeposits.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Models
{
    public class AccountNumber
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client{ get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Base { get; set; }
        public double Debet { get; set; }
        public double Credit { get; set; }
        public double Saldo { get; set; }
    }
}