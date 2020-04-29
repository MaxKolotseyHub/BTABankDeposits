using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Models
{
    public class DepositType
    {
        public int Id { get; set; }
        [Display(Name = "Тип вклада")]
        public string Name { get; set; }
        [Display(Name = "Процент по вкладу")]
        public double Percent { get; set; }
    }
}