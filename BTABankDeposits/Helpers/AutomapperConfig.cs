using AutoMapper;
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
            if(mapper == null)
            {
                var config = new MapperConfiguration(cfg=>
                {
                    cfg.CreateMap<Client, ClientsListViewModel>()
                    .ForMember("Name", opt => opt.MapFrom(c => c.SecondName + " " + c.FirstName + " " + c.ThirdName));
                });

                mapper = new Mapper(config);
            }
            return mapper;
        }
    }
}