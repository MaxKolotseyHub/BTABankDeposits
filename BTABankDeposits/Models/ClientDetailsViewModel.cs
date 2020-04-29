using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Models
{
    public class ClientDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name="ФИО")]
        public string Name { get; set; }
        [Display(Name = "Идентификационный номер клиента")]
        public string ClientId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Пол")]
        [Required]
        public string Gender { get; set; }
        [Display(Name = "Паспортные данные")]
        [Required]
        public string PassportData { get; set; }
        [Display(Name = "Место рождения")]
        [Required]
        public string BirthPlace { get; set; }
        [Display(Name = "Место фактического проживания")]
        [Required]
        public string LivingPlace { get; set; }
        [Display(Name = "Контакты")]
        //[RegularExpression(@"(\d{7})", ErrorMessage ="Должен состоять из 7 цифр")]
        [Required]
        public string Contacts { get; set; }
        [Display(Name = "Место работы")]
        [Required]
        public string WorkPlaceInfo { get; set; }
        [Display(Name = "Прописан")]
        public string RegistrationPlace { get; set; }
        [Display(Name = "Семейное положение")]
        [Required]
        public string MaritalStatus { get; set; }
        [Display(Name = "Гражданство")]
        [Required]
        public string Citizenship { get; set; }
        [Display(Name = "Инвалидность")]
        [Required]
        public string Invalidity { get; set; }
        [Display(Name = "Пенсионер")]
        [Required]
        public string Pensioner { get; set; }
        [Display(Name = "Ежемесячный доход")]
        [Required]
        public double MonthlyIncome { get; set; }
        [Display(Name = "Военнообязаный")]
        [Required]
        public string DutyBound { get; set; }
    }
}