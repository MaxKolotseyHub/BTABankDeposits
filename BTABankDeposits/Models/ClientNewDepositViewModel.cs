using BTABankDeposits.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Models
{
    public class ClientNewDepositViewModel
    {
        public int Id { get; set; }
        [Display(Name = "ФИО")]
        public string Name { get; set; }
        [Display(Name = "Идентификационный номер клиента")]
        public int ClientId { get; set; }
        public Client Client{ get; set; }
        public int DepositTypeId { get; set; }
        public int CurrencyId { get; set; }
        [Display(Name = "Номер договора")]
        public string ContractNumber { get; set; }
        [Display(Name = "Дата начала депозитной программы")]
        public DateTime Start { get; set; }
        [Display(Name = "Дата оконнчания депозитной программы")]
        public DateTime End { get; set; }
        [Display(Name = "Срок договора")]
        public int ContractDuration { get; set; }
        [Display(Name = "Сумма вклада")]
        public double DepositSum { get; set; }
    }
}