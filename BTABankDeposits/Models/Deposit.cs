using BTABankDeposits.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Models
{
    public class Deposit
    {
        public Deposit()
        {
            AccountNumbers = new List<AccountNumber>();
        }
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client{ get; set; }
        public int DepositTypeId { get; set; }
        public virtual DepositType DepositType { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual List<AccountNumber> AccountNumbers{ get; set; }
        [Display(Name = "Номер договора")]
        public string ContractNumber { get; set; }
        [Display(Name = "Дата начала депозитной программы")]
        public DateTime Start { get; set; }
        [Display(Name = "Дата окончания депозитной программы")]
        public DateTime End { get; set; }
        [Display(Name = "Срок договора (В Днях)")]
        public int ContractDuration { get; set; }
        [Display(Name = "Сумма вклада")]
        public double DepositSum { get; set; }
        public bool IsHandled { get; set; } = false;
        public bool IsInterrupted {get; set; } = false;
        public bool Closed { get; set; } = false;
        public string CurrentState { get; set; }
    }
}
