using BTABankDeposits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Helpers
{
    public interface IDepositAccountNumbersFactory
    {
        AccountNumber CreateCheckingAccount(Deposit deposit);
        AccountNumber CreatePercentAccount(Deposit deposit);
    }
}