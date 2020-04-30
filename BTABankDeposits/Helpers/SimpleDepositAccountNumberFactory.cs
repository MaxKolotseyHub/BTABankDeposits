using BTABankDeposits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Helpers
{
    public class SimpleDepositAccountNumberFactory : IDepositAccountNumbersFactory
    {
        public AccountNumber CreateCheckingAccount(Deposit deposit)
        {
            int intSuffix = 0;
            string suffix = "";
            var Suffixes = deposit.Client.AccountNumbers.Where(x => x.Prefix == "3014").ToList();
            if (Suffixes.Count == 0)
            {
                intSuffix = 1;
            }
            else
            {
                intSuffix = Suffixes.Select(x => Int32.Parse(x.Suffix)).Max();
            }



            if (intSuffix > 99)
            {
                suffix = intSuffix.ToString();
            }
            else if (intSuffix > 9)
            {
                suffix = "0" + intSuffix.ToString();
            }
            else
            {
                suffix = "00" + intSuffix.ToString();
            }
            var number = new AccountNumber()
            {
                Prefix = "3014",
                Base = deposit.Client.ClientId,
                Suffix = suffix,
                Client = deposit.Client,
                AccountType = AccountType.Passive,
                Credit = 0,
                Debet = 0
            };

            return number;
        }

        public AccountNumber CreatePercentAccount(Deposit deposit)
        {
            int intSuffix = 0;
            string suffix = "";
            var Suffixes = deposit.Client.AccountNumbers.Where(x => x.Prefix == "1230").ToList();
            if (Suffixes.Count == 0)
            {
                intSuffix = 1;
            }
            else
            {
                intSuffix = Suffixes.Select(x => Int32.Parse(x.Suffix)).Max();
            }

            if (intSuffix > 99)
            {
                suffix = intSuffix.ToString();
            }
            else if (intSuffix > 9)
            {
                suffix = "0" + intSuffix.ToString();
            }
            else
            {
                suffix = "00" + intSuffix.ToString();
            }
            var number = new AccountNumber()
            {
                Prefix = "1230",
                Base = deposit.Client.ClientId,
                Suffix = suffix,
                Client = deposit.Client,
                AccountType = AccountType.Passive,
                Credit = 0,
                Debet = 0
            };
            return number;
        }
    }
}