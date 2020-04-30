using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTABankDeposits.Helpers
{
    internal interface IEndOfBankDay
    {
        void HandleNewDeposits();
        void CountDepositPercents();
    }
}
