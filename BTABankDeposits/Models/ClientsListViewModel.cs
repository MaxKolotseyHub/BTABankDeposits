using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Models
{
    public class ClientsListViewModel
    {
        public int Id { get; set; }
        [Display(Name="ФИО")]
        public string Name { get; set; }
        [Display(Name="Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name="Моб. Телефон")]
        public string PhoneNumberMobile { get; set; }
    }
}