using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Models
{
    public class DepositListViewModel
    {
        public int Id { get; set; }
        [Display(Name="Номер договора")]
        public string ContractNumber { get; set; }
        [Display(Name = "Тип депозита")]
        public string DepositType{ get; set; }
        [Display(Name = "Процентная ставка")]
        public double DepositPercent{ get; set; }
        [Display(Name="Срок депозита (дней)")]
        public int ContractDuration { get; set; }
        [Display(Name="До конца срока (дней)")]
        public int TillEnd { get; set; }
        [Display(Name="Начисленные проценты")]
        public double InterestCharges { get; set; }
        [Display(Name="Сумма депозита")]
        public double DepositSum { get; set; }
    }
}