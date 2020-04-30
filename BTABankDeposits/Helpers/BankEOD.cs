using BTABankDeposits.Db;
using BTABankDeposits.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Helpers
{
    public class BankEOD : IEndOfBankDay
    {
        private readonly MyDbContext db;
        private readonly IDepositAccountNumbersFactory factory;

        public BankEOD(MyDbContext db)
        {
            this.db = db;
            factory = new SimpleDepositAccountNumberFactory();
        }

        public void CountDepositPercents()
        {
            var cashierAccount = db.AccountNumbers.FirstOrDefault(x => x.Base == "111111" & x.Prefix == "1010");
            var fondAccount = db.AccountNumbers.FirstOrDefault(x => x.Base == "111111" & x.Prefix == "7327");
            var deposits = db.Deposits.ToList();
            foreach (var deposit in deposits)
            {
                if (deposit.IsInterrupted & !deposit.Closed)
                {
                    deposit.Closed = true;
                    deposit.AccountNumbers.FirstOrDefault(x => x.Prefix == "3014").Credit += deposit.DepositSum;
                    deposit.AccountNumbers.FirstOrDefault(x => x.Prefix == "1230").Credit = 0;
                    deposit.CurrentState = "Прерван";
                }
                if (!deposit.Closed)
                {
                    
                    if (deposit.Start.AddDays(deposit.ContractDuration) <= DateTime.Now)
                    {
                        if (!deposit.Closed)
                        {
                            deposit.Closed = true;
                            fondAccount.Debet += deposit.DepositSum;
                            deposit.AccountNumbers.FirstOrDefault(x => x.Prefix == "3014").Credit += deposit.DepositSum;
                            CountPercents(deposit, fondAccount);
                            deposit.CurrentState = "Закрыт";
                        }
                    }
                    else
                    {
                        CountPercents(deposit, fondAccount);
                            deposit.CurrentState = "Открыт";
                    }
                }
                db.Entry(deposit).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        private void CountPercents(Deposit deposit, AccountNumber fondAccount)
        {
            int daysFromStart = (DateTime.Now.Date - deposit.Start.Date).Days;
            if (daysFromStart > deposit.ContractDuration)
                daysFromStart = deposit.ContractDuration;
            double percentsPerDay = (deposit.DepositType.Percent / 365 * daysFromStart) / 100;
            double interestCharges = deposit.DepositSum * percentsPerDay;
            fondAccount.Debet += interestCharges;
            deposit.AccountNumbers.FirstOrDefault(x => x.Prefix == "1230").Credit = interestCharges;
        }
        public void HandleNewDeposits()
        {
            var unhandled = db.Deposits.Where(x => !x.IsHandled).ToList();
            var cashierAccount = db.AccountNumbers.FirstOrDefault(x => x.Base == "111111" & x.Prefix == "1010");
            var fondAccount = db.AccountNumbers.FirstOrDefault(x => x.Base == "111111" & x.Prefix == "7327");
            if (unhandled.Count != 0)
            {
                foreach (var deposit in unhandled)
                {
                    var checkingAccount = factory.CreateCheckingAccount(deposit);
                    var percentAccount = factory.CreatePercentAccount(deposit);

                    cashierAccount.Debet += deposit.DepositSum;
                    cashierAccount.Credit += cashierAccount.Debet;

                    checkingAccount.Credit += cashierAccount.Debet;
                    checkingAccount.Debet += checkingAccount.Credit;

                    fondAccount.Credit += checkingAccount.Credit;

                    deposit.IsHandled = true;

                    deposit.AccountNumbers.Add(checkingAccount);
                    deposit.AccountNumbers.Add(percentAccount);

                    db.Entry(deposit).State = EntityState.Modified;
                    db.Entry(fondAccount).State = EntityState.Modified;
                    db.Entry(cashierAccount).State = EntityState.Modified;

                }

                db.SaveChanges();
            }

        }
    }
}