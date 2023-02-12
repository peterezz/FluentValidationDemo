using DairElAnbaBeshoy.AppLogic.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.AppLogic.Validators
{
    public class RetreaveValidator : AbstractValidator<RetreaveVM>
    {
        public RetreaveValidator()
        {
            RuleFor(prop => prop.LoggedinUserId)
                .NotNull();
            RuleFor(prop => prop.ReserverFullName)
                .NotEmpty()
                .WithMessage("يجب ادخال اسم حاجز الخلوة");
            RuleFor(prop=>prop.ResrversNumber)
                .NotEmpty()
                .WithMessage("يجب ادخال عدد الافراد")
                .GreaterThan(0)
                .WithMessage("عدد الافراد غير صحيح");
            RuleFor(prop => prop.ReserveDateTime)
                .Must(prop => prop == null)
                    .WithMessage("يجب اختيار يوم معين")
                .DependentRules(() =>
                {
                    RuleFor(prop => prop.ReserveDateTime)
                   .Must(prop => prop > DateTime.Now)
                  .WithMessage("يجب على الاقل حجز خلوة بعد يوم من الان");
                });


            RuleFor(prop => prop.Governorate)
                .NotEmpty()
                .WithMessage("يجب ادخال اسم المحافظة");
            RuleFor(prop => prop.IdCardPhotoFile)
                .NotEmpty()
                .WithMessage("يجب ادخال صورة البطاقة");



        }
    }
}
