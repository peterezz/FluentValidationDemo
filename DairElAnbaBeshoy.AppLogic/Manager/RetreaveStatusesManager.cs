using AutoMapper;
using DairElAnbaBeshoy.AppLogic.Repository;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Models;

namespace DairElAnbaBeshoy.AppLogic.Manager
{
    public class RetreaveStatusesManager
    {
        private readonly BaseRepo<RetreaveStatuses> repo;
        private readonly IMapper mapper;

        public RetreaveStatusesManager( ApplicationDbContext context , IMapper mapper )
        {
            this.mapper = mapper;
            repo = new BaseRepo<RetreaveStatuses>( context );
        }
        public void AddRetreaveStatus( RetreaveStatusesVM retreaveStatusVM )
        {
            var data = mapper.Map<RetreaveStatuses>( retreaveStatusVM );
            repo.Add( data );
        }
    }
}
