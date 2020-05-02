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
            Deposits = new List<Deposit>();
        }
        public int Id { get; set; }
        [Display(Name ="Идентификационный номер клиента")]
        public string ClientId { get; set; }
        public virtual List<AccountNumber> AccountNumbers{ get; set; }
        public virtual List<Deposit> Deposits{ get; set; }
        [Display(Name ="Имя")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string FirstName { get; set; }
        [Display(Name ="Фамилия")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string SecondName { get; set; }
        [Display(Name ="Отчество")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string ThirdName { get; set; }
        [Display(Name ="Дата рождения")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public DateTime BirthDate { get; set; }
        [Display(Name ="Пол")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string Gender { get; set; }
        [RegularExpression("([A-Z]{2})", ErrorMessage = "Должен состоять из двух заглавных латинских букв")]
        [Display(Name ="Серия паспорта")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string PassportSeries { get; set; }
        [Display(Name ="Номер паспорта")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string PassportNumber{ get; set; }
        [Display(Name ="Кем выдан")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string PassportCreator { get; set; }
        [Display(Name ="Дата выдачи")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public DateTime PassportCreatedDate { get; set; }
        [Display(Name ="Идентификационный номер паспорта")]
        [RegularExpression(@"(\d{7}[A-Z]{1}\d{3}[A-Z]{2}\d{1})", ErrorMessage ="Некорректно введен идентификационный номер")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string PassportId { get; set; }
        [Display(Name ="Место рождения")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string BirthPlace { get; set; }
        [Display(Name ="Город фактического проживания")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string LivingCity{ get; set; }
        [Display(Name ="Адрес фактического проживания")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string LivingAddress { get; set; }
        [Display(Name ="Телефон домашний")]
        //[RegularExpression(@"(\d{7})", ErrorMessage ="Должен состоять из 7 цифр")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string PhoneNumberHome { get; set; }
        [Display(Name ="Телефон мобильный")]
        [RegularExpression(@"(.\d{12})", ErrorMessage = "Введите с кодом +375")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string PhoneNumberMobile { get; set; }
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string Email { get; set; }
        [Display(Name ="Место работы")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string WorkPlace { get; set; }
        [Display(Name ="Должность")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string WorkPosition { get; set; }
        [Display(Name ="Город прописки")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string RegistrationCity { get; set; }
        [Display(Name ="Адрес прописки")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string RegistrationAddress { get; set; }
        [Display(Name ="Семейное положение")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string MaritalStatus { get; set; }
        [Display(Name ="Гражданство")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string Citizenship { get; set; }
        [Display(Name ="Инвалидность")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public string Invalidity { get; set; }
        [Display(Name ="Пенсионер")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public bool IsPensioner{ get; set; }
        [Display(Name ="Ежемесячный доход")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public double MonthlyIncome { get; set; }
        [Display(Name ="Военнообязаный")]
        [Required(ErrorMessage ="Поле необходимо для заполнения")]
        public bool IsDutyBound { get; set; }
    }
}