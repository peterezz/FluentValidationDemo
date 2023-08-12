using AutoMapper;
using DairElAnbaBeshoy.AppLogic.Repository;
using DairElAnbaBeshoy.AppLogic.Validators;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Manager;
using DairElAnbaBeshoy.Core.Models;
using FluentValidation.Results;

namespace DairElAnbaBeshoy.AppLogic.Manager
{
    public class RetreaveManager
    {
        private readonly BaseRepo<Retreaves> RetriveRepo;
        private readonly IMapper mapper;
        private readonly RetreaveStatusesManager retreaveStatusesManager;
        private readonly RetreaveValidator validators;
        int totalPlaces = 30;

        public RetreaveManager( ApplicationDbContext context , IMapper mapper , RetreaveStatusesManager retreaveStatusesManager )
        {
            RetriveRepo = new BaseRepo<Retreaves>( context );
            this.mapper = mapper;
            this.retreaveStatusesManager = retreaveStatusesManager;
            this.validators = new RetreaveValidator( );
        }

        public RetreaveVM RegisterRetreave( RetreaveVM retreaveVM )
        {
            ValidationResult ValidateResult = validators.Validate( retreaveVM );
            if ( !ValidateResult.IsValid || !RetreaveRequestIsValid( retreaveVM ) )
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

            RetreaveRequestIsValid( retreaveVM );
            return retreaveVM;
        }

        // approve retreave requeest logic
        public RetreaveVM UpdateRetreave( RetreaveVM retreaveVM )
        {

            //admin can not approve the retrieve if the approved retrieves + requested number of retrieves is more than 30 places
            if ( !RetreaveRequestIsValid( retreaveVM ) )
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

        /// <summary>
        /// validate retreave request
        /// </summary>
        /// <param name="retreaveVM">retreave request</param>
        /// <returns>true if request is valid, otherwise false is returned</returns>
        private bool RetreaveRequestIsValid( RetreaveVM retreaveVM )
        {

            DateTime previousReserveDateTime = retreaveVM.ReserveDateTime.Date.AddDays( -1 );
            DateTime succeedingReserveDateTime = retreaveVM.ReserveDateTime.Date.AddDays( 1 );
            int maxPlaces = 30;
            // Check if number of reserves of day before or current day or succeeding day does not contains more than 30 reservers 
            var sumPreviousReservations = RetriveRepo.SumWhere( retreave => retreave.IsApproved ?? false && retreave.ResrveDate.Date.Equals( previousReserveDateTime.Date ) , sum => sum.ResrversNumber );
            var sumCurrentReservations = RetriveRepo.SumWhere( retreave => retreave.IsApproved ?? false && retreave.ResrveDate.Date.Equals( retreaveVM.ReserveDateTime.Date ) , sum => sum.ResrversNumber );
            var sumSucceedingReservations = RetriveRepo.SumWhere( retreave => retreave.IsApproved ?? false && retreave.ResrveDate.Date.Equals( succeedingReserveDateTime.Date ) , sum => sum.ResrversNumber );

            if ( (sumPreviousReservations + retreaveVM.ResrversNumber <= maxPlaces) ||
                (sumCurrentReservations + retreaveVM.ResrversNumber <= maxPlaces) ||
                (sumSucceedingReservations + retreaveVM.ResrversNumber <= maxPlaces) )
                retreaveVM.IsApproaved = true;

            return retreaveVM.IsApproaved;
        }

    }
}
