using BTABankDeposits.Controllers;
using BTABankDeposits.Db;
using BTABankDeposits.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Db
{
    public class MyDbContextInitializer: DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            var client1 = new Client() {
                BirthDate = new DateTime(1998, 7, 16),
                BirthPlace = "г. Минск",
                Citizenship = "РБ",
                Email = "randomemail@gmail.com",
                FirstName = "Алексей",
                Invalidity = "Нет",
                IsDutyBound = true,
                Gender="М",
                IsPensioner = false,
                LivingAddress = "Улица Пушкина, дом Колотушкина",
                LivingCity = "Минск",
                MaritalStatus = "Не женат",
                MonthlyIncome = 760,
                PassportCreatedDate = new DateTime(2016,08,13),
                PassportCreator ="Минский РОВД",
                PassportId = "1234567C123GB1",
                PassportNumber="2324123",
                PassportSeries="MC",
                PhoneNumberHome="2603231",
                PhoneNumberMobile="+375256161611",
                RegistrationAddress="ул. П. Бровки 4а",
                RegistrationCity= "г. Минск",
                SecondName="Шевцов",
                ThirdName="Иванович",
                WorkPlace="БГУИР",
                WorkPosition="Менеджер проектов",
                ClientId = "726478"

            };

            var client2 = new Client()
            {
                BirthDate = new DateTime(1998, 7, 16),
                BirthPlace = "г. Минск",
                Citizenship = "РБ",
                Email = "superrandomemail@gmail.com",
                FirstName = "Клёпа",
                Invalidity = "Нет",
                IsDutyBound = true,
                Gender="М",
                IsPensioner = false,
                LivingAddress = "Улица Шугаева 19/1/142",
                LivingCity = "Минск",
                MaritalStatus = "Не женат",
                MonthlyIncome = 760,
                PassportCreatedDate = new DateTime(2016, 08, 13),
                PassportCreator = "Минский РОВД",
                PassportId = "3434567C123GB1",
                PassportNumber = "2312123",
                PassportSeries = "MC",
                PhoneNumberHome = "2606060",
                PhoneNumberMobile = "+375256999611",
                RegistrationAddress = "ул. Зеленых вертолетов 7б",
                RegistrationCity = "г. Минск",
                SecondName = "Юдашкин",
                ThirdName = "Лисабонович",
                WorkPlace = "Министерство борьбы с населением",
                WorkPosition = "Радикал",
                ClientId = "123232"
            };

            context.Clients.Add(client1);
            context.Clients.Add(client2);

            List<City> cities = new List<City>()
            {
                new City(){Name="Минск"},
                new City(){Name="Гомель"},
                new City(){Name="Гродно"},
                new City(){Name="Витебск"},
                new City(){Name="Брест"},
                new City(){Name="Могилев" }
            };

            cities.ForEach(x => context.Cities.Add(x));

            List<Currency> Currencies = new List<Currency>
            {
                new Currency{ Name = "EUR"},
                new Currency{ Name = "BYN"},
                new Currency{ Name = "USD"},
                new Currency{ Name = "RUR"}
            };

            Currencies.ForEach(x=>context.Currencies.Add(x));

            List<DepositType> DepositTypes = new List<DepositType>
            {
                new DepositType{ Name = "Депозит до восстребования" , Percent = 7.6},
                new DepositType{ Name = "Депозит на месяц" , Percent = 10}
            };

            DepositTypes.ForEach(x=>context.DepositTypes.Add(x));

            base.Seed(context);
        }
    }
}