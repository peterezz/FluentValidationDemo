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
        private readonly RetreaveValidator validators;

        public RegisterRetreaveManager(ApplicationDbContext context, IMapper mapper)
        {
             RetriveRepo= new BaseRepo<Retreaves>(context);
            this.mapper = mapper;
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

    }
}
