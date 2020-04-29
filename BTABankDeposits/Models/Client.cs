using BTABankDeposits.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Controllers
{
    public class Client
    {
        public Client()
        {
            AccountNumbers = new List<AccountNumber>();
        }
        public int Id { get; set; }
        [Display(Name ="Идентификационный номер клиента")]
        public string ClientId { get; set; }
        public List<AccountNumber> AccountNumbers{ get; set; }
        [Display(Name ="Имя")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name ="Фамилия")]
        [Required]
        public string SecondName { get; set; }
        [Display(Name ="Отчество")]
        [Required]
        public string ThirdName { get; set; }
        [Display(Name ="Дата рождения")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Display(Name ="Пол")]
        [Required]
        public string Gender { get; set; }
        [RegularExpression("([A-Z]{2})", ErrorMessage = "Должен состоять из двух заглавных латинских букв")]
        [Display(Name ="Серия паспорта")]
        [Required]
        public string PassportSeries { get; set; }
        [Display(Name ="Номер паспорта")]
        [Required]
        public string PassportNumber{ get; set; }
        [Display(Name ="Кем выдан")]
        [Required]
        public string PassportCreator { get; set; }
        [Display(Name ="Дата выдачи")]
        [Required]
        public DateTime PassportCreatedDate { get; set; }
        [Display(Name ="Идентификационный номер паспорта")]
        [RegularExpression(@"(\d{7}[A-Z]{1}\d{3}[A-Z]{2}\d{1})", ErrorMessage ="Некорректно введен идентификационный номер")]
        [Required]
        public string PassportId { get; set; }
        [Display(Name ="Место рождения")]
        [Required]
        public string BirthPlace { get; set; }
        [Display(Name ="Город фактического проживания")]
        [Required]
        public string LivingCity{ get; set; }
        [Display(Name ="Адрес фактического проживания")]
        [Required]
        public string LivingAddress { get; set; }
        [Display(Name ="Телефон домашний")]
        //[RegularExpression(@"(\d{7})", ErrorMessage ="Должен состоять из 7 цифр")]
        [Required]
        public string PhoneNumberHome { get; set; }
        [Display(Name ="Телефон мобильный")]
        [RegularExpression(@"(.\d{12})", ErrorMessage = "Введите с кодом +375")]
        [Required]
        public string PhoneNumberMobile { get; set; }
        [Display(Name ="Email")]
        [Required]
        public string Email { get; set; }
        [Display(Name ="Место работы")]
        [Required]
        public string WorkPlace { get; set; }
        [Display(Name ="Должность")]
        [Required]
        public string WorkPosition { get; set; }
        [Display(Name ="Город прописки")]
        [Required]
        public string RegistrationCity { get; set; }
        [Display(Name ="Адрес прописки")]
        [Required]
        public string RegistrationAddress { get; set; }
        [Display(Name ="Семейное положение")]
        [Required]
        public string MaritalStatus { get; set; }
        [Display(Name ="Гражданство")]
        [Required]
        public string Citizenship { get; set; }
        [Display(Name ="Инвалидность")]
        [Required]
        public string Invalidity { get; set; }
        [Display(Name ="Пенсионер")]
        [Required]
        public bool IsPensioner{ get; set; }
        [Display(Name ="Ежемесячный доход")]
        [Required]
        public double MonthlyIncome { get; set; }
        [Display(Name ="Военнообязаный")]
        [Required]
        public bool IsDutyBound { get; set; }
    }
}