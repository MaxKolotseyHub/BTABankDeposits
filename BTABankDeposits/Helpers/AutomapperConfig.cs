﻿using AutoMapper;
using BTABankDeposits.Controllers;
using BTABankDeposits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTABankDeposits.Helpers
{
    public class AutomapperConfig
    {
        private static Mapper mapper;
        public static Mapper GetMapper()
        {
            if (mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Client, ClientsListViewModel>()
                    .ForMember("Name", opt => opt.MapFrom(c => c.SecondName + " " + c.FirstName + " " + c.ThirdName))
                    .ForMember("DepositCount", opt => opt.MapFrom(c => c.Deposits.Where(x=>x.IsHandled).ToList().Count));

                    cfg.CreateMap<Client, ClientDetailsViewModel>()
                    .ForMember("Name", opt => opt.MapFrom(c => c.SecondName + " " + c.FirstName + " " + c.ThirdName))
                    .ForMember("PassportData", opt => opt.MapFrom(c => "Номер паспорта: " + c.PassportSeries + c.PassportNumber +
                     "\nВыдан: " + c.PassportCreator + " " + c.PassportCreatedDate.ToShortDateString() +
                     "\nИдентификацонный номер: " + c.PassportId))
                    .ForMember("LivingPlace", opt => opt.MapFrom(c => "г. " + c.LivingCity + ", " + c.LivingAddress))
                    .ForMember("Contacts", opt => opt.MapFrom(c => "Мобильный телефон: " + c.PhoneNumberMobile +
                    "\nДомашний телефон: " + c.PhoneNumberHome +
                    "\nEmail: " + c.Email))
                    .ForMember("WorkPlaceInfo", opt => opt.MapFrom(c => c.WorkPlace + "\nДолжность: " + c.WorkPosition))
                    .ForMember("RegistrationPlace", opt => opt.MapFrom(c => "г. " + c.RegistrationCity + " " + c.RegistrationAddress))
                    .ForMember("Pensioner", opt => opt.MapFrom(c => c.IsPensioner ? "Да" : "Нет"))
                    .ForMember("DutyBound", opt => opt.MapFrom(c => c.IsDutyBound ? "Да" : "Нет"))
                    .ForMember("ClientId", opt => opt.MapFrom(c => c.ClientId));

                    cfg.CreateMap<Deposit, DepositListViewModel>()
                    .ForMember("InterestCharges", opt => opt.MapFrom(c =>String.Format("{0:0.00}", c.AccountNumbers.FirstOrDefault(x => x.Prefix == "1230").Credit)))
                    .ForMember("Status", opt => opt.MapFrom(c => c.CurrentState))
                    .ForMember("DepositType", opt => opt.MapFrom(c => c.DepositType.Name))
                    .ForMember("DepositPercent", opt => opt.MapFrom(c => c.DepositType.Percent))
                    .ForMember("TillEnd", opt => opt.MapFrom(c => c.ContractDuration - (DateTime.Now.Date - c.Start.Date).Days));

                    //cfg.CreateMap<Deposit, ClientNewDepositViewModel>();
                    //cfg.CreateMap<Currency, ClientNewDepositViewModel>()
                    //.ForMember("Currency", opt=> opt.MapFrom(c=>c.Name));
                    //cfg.CreateMap<Client, ClientNewDepositViewModel>()
                    //.ForMember("Name", opt => opt.MapFrom(c => c.SecondName + " " + c.FirstName + " " + c.ThirdName))
                    //.ForMember("ClientId", opt => opt.MapFrom(c => c.ClientId));
                    //cfg.CreateMap<DepositType, ClientNewDepositViewModel>()
                    //.ForMember("DepositType", opt => opt.MapFrom(c => c.Name));
                });

                mapper = new Mapper(config);
            }
            return mapper;
        }
    }
}