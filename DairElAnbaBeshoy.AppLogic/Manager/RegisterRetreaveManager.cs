using AutoMapper;
using DairElAnbaBeshoy.AppLogic.Validators;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Manager;
using DairElAnbaBeshoy.Core.Models;
using DairElAnbaBeshoy.Core.Repository;
using FluentValidation.Results;
using LanguageExt;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.AppLogic.Manager
{
    public class RegisterRetreaveManager
    {
        private readonly BaseRepo<Retreaves> RetriveRepo;
        private readonly IMapper mapper;
        private readonly RetreaveStatusesManager retreaveStatusesManager;
        private readonly RetreaveValidator validators;

        public RegisterRetreaveManager(ApplicationDbContext context, IMapper mapper,RetreaveStatusesManager retreaveStatusesManager)
        {
             RetriveRepo= new BaseRepo<Retreaves>(context);
            this.mapper = mapper;
            this.retreaveStatusesManager = retreaveStatusesManager;
            this.validators = new RetreaveValidator();
        }

        public void RegisterRetreave(RetreaveVM retreaveVM)
        {
            ValidationResult ValidateResult = validators.Validate(retreaveVM);
            if (!ValidateResult.IsValid)
                 return;
            retreaveVM.IdCardPhoto = FileManger.UploadPhoto(retreaveVM.IdCardPhotoFile, "/images/IdCards/", 150, 150);
            var data= mapper.Map<Retreaves>(retreaveVM);
            RetriveRepo.Add(data);

        }
        public List<RetreaveVM>GetAllRetrives(string reserverFullName)
        {
            IQueryable<Retreaves> data;
            if (string.IsNullOrEmpty(reserverFullName))
            {
               data  = RetriveRepo.GetAll();
                return mapper.Map<List<RetreaveVM>>(data);
            }
             data = RetriveRepo.GetMany(reserver=>reserver.ReserverFullName.Contains(reserverFullName));
            return mapper.Map<List<RetreaveVM>>(data);

        }
        public RetreaveVM GetRetreave(int ReservationID)
        {
            var data = RetriveRepo.Get(ReservationID);
            return mapper.Map<RetreaveVM>(data);
        }
        public void UpdateRetreave(RetreaveVM retreaveVM)
        {
            
            Retreaves retreave = mapper.Map<Retreaves>(retreaveVM);
            RetriveRepo.Edit(retreave);
        }
        public void DeleteRetreave(RetreaveVM retreave)
        {

            RetreaveStatusesVM retreaveStatus = new RetreaveStatusesVM()
            {
                UserId = retreave.LoggedinUserId,
                ReservationDate = retreave.ReserveDateTime,
                ReservationStatus = false
                
            };
            retreaveStatusesManager.AddRetreaveStatus(retreaveStatus);
            RetriveRepo.Delete(retreave.Id);
        }

    }
}
