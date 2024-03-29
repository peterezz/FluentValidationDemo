﻿using AutoMapper;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.AppLogic.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Retreaves, RetreaveVM>()
                .ForMember(retreaveVM => retreaveVM.ReserveDateTime
                , map=>map.MapFrom(retreve => retreve.ResrveDate
                )).ReverseMap();
            CreateMap<RetreaveStatuses, RetreaveStatusesVM>().ReverseMap();
        }
    }
}
