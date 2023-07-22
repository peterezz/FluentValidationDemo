using AutoMapper;
using DairElAnbaBeshoy.AppLogic.Repository;
using DairElAnbaBeshoy.AppLogic.Validators;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Manager;
using DairElAnbaBeshoy.Core.Models;
using FluentValidation.Results;

namespace DairElAnbaBeshoy.AppLogic.Manager
{
    public class RegisterRetreaveManager
    {
        private readonly BaseRepo<Retreaves> RetriveRepo;
        private readonly IMapper mapper;
        private readonly RetreaveStatusesManager retreaveStatusesManager;
        private readonly RetreaveValidator validators;
        int totalPlaces = 30;

        public RegisterRetreaveManager( ApplicationDbContext context , IMapper mapper , RetreaveStatusesManager retreaveStatusesManager )
        {
            RetriveRepo = new BaseRepo<Retreaves>( context );
            this.mapper = mapper;
            this.retreaveStatusesManager = retreaveStatusesManager;
            this.validators = new RetreaveValidator( );
        }

        public RetreaveVM RegisterRetreave( RetreaveVM retreaveVM )
        {
            ValidationResult ValidateResult = validators.Validate( retreaveVM );
            if ( !ValidateResult.IsValid )
                return null;
            var sumReservations = RetriveRepo.SumWhere( retreave => retreave.IsApproved ?? false && retreave.ResrveDate.Date.Equals( retreaveVM.ReserveDateTime.Date ) , sum => sum.ResrversNumber );
            if ( sumReservations + retreaveVM.ResrversNumber >= 30 )
                return null;
            retreaveVM.IdCardPhoto = FileManger.UploadPhoto( retreaveVM.IdCardPhotoFile , "/images/IdCards/" , 150 , 150 );
            var data = mapper.Map<Retreaves>( retreaveVM );
            RetriveRepo.Add( data );
            return retreaveVM;

        }
        public List<RetreaveVM> GetAllRetrives( string reserverFullName )
        {
            IQueryable<Retreaves> data;
            if ( string.IsNullOrEmpty( reserverFullName ) )
            {
                data = RetriveRepo.GetAll( );
                return mapper.Map<List<RetreaveVM>>( data );
            }
            data = RetriveRepo.GetMany( reserver => reserver.ReserverFullName.Contains( reserverFullName ) );
            return mapper.Map<List<RetreaveVM>>( data );

        }
        public RetreaveVM GetRetreave( int ReservationID )
        {

            var data = RetriveRepo.Get( ReservationID );
            var retreaveVM = mapper.Map<RetreaveVM>( data );

            //get total number of approved retrieves in that day
            var sumReservations = RetriveRepo.SumWhere( retreave => retreave.IsApproved ?? false && retreave.ResrveDate.Date.Equals( retreaveVM.ReserveDateTime.Date ) , sum => sum.ResrversNumber );
            retreaveVM.ThatDayReserves = sumReservations;
            retreaveVM.NumEmptyPlaces = totalPlaces - retreaveVM.ThatDayReserves;

            return retreaveVM;
        }
        public RetreaveVM UpdateRetreave( RetreaveVM retreaveVM )
        {

            //admin can not approve the retrieve if the approve retrieves + requested number of retrieves is more than 30 places
            var sumReservations = RetriveRepo.SumWhere( retreave => retreave.IsApproved ?? false && retreave.ResrveDate.Date.Equals( retreaveVM.ReserveDateTime.Date ) , sum => sum.ResrversNumber );
            if ( sumReservations + retreaveVM.ResrversNumber > totalPlaces )
                return null;
            Retreaves retreave = mapper.Map<Retreaves>( retreaveVM );
            RetriveRepo.Edit( retreave );
            return retreaveVM;
        }
        public void DeleteRetreave( RetreaveVM retreave )
        {

            RetreaveStatusesVM retreaveStatus = new RetreaveStatusesVM( )
            {
                UserId = retreave.LoggedinUserId ,
                ReservationDate = retreave.ReserveDateTime ,
                ReservationStatus = false

            };
            retreaveStatusesManager.AddRetreaveStatus( retreaveStatus );
            FileManger.DeleteFile( $"/images/IdCards/{retreave.IdCardPhoto}" );
            RetriveRepo.Delete( retreave.Id );
        }

    }
}
