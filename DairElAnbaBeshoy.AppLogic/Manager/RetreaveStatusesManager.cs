using AutoMapper;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Models;
using DairElAnbaBeshoy.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.AppLogic.Manager
{
    public class RetreaveStatusesManager
    {
        private readonly BaseRepo<RetreaveStatuses> repo;
        private readonly IMapper mapper;

        public RetreaveStatusesManager(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            repo = new BaseRepo<RetreaveStatuses>(context);
        }
        public void AddRetreaveStatus(RetreaveStatusesVM retreaveStatusVM)
        {
            var data= mapper.Map<RetreaveStatuses>(retreaveStatusVM);
            repo.Add(data);
        }
    }
}
