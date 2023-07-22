using DairElAnbaBeshoy.AppLogic.ViewModel;
using FluentValidation;

namespace DairElAnbaBeshoy.AppLogic.Validators
{
    public class RetreaveValidator : AbstractValidator<RetreaveVM>
    {
        public RetreaveValidator( )
        {
            RuleFor( prop => prop.LoggedinUserId )
                .NotNull( );
            RuleFor( prop => prop.ReserverFullName )
                .NotEmpty( )
                .WithMessage( "يجب ادخال اسم حاجز الخلوة" );
            RuleFor( prop => prop.ResrversNumber )
                .NotEmpty( )
                .WithMessage( "يجب ادخال عدد الافراد" )
                .GreaterThan( 0 )
                .WithMessage( "عدد الافراد غير صحيح" );
            RuleFor( prop => prop.ReserveDateTime )
                .NotEmpty( )
                    .WithMessage( "يجب اختيار يوم معين" )
                .DependentRules( ( ) =>
                {
                    RuleFor( prop => prop.ReserveDateTime )
                   .Must( prop => prop > DateTime.Now )
                  .WithMessage( "يجب على الاقل حجز خلوة بعد يوم من الان" );
                } );


            RuleFor( prop => prop.Governorate )
                .NotEmpty( )
                .WithMessage( "يجب ادخال اسم المحافظة" );
            RuleFor( prop => prop.IdCardPhotoFile )
                .NotEmpty( )
                .WithMessage( "يجب ادخال صورة البطاقة" )
                .DependentRules( ( ) =>
                {
                    RuleFor( prop => prop.IdCardPhotoFile.FileName )
                    .Matches( "^.+\\.(jpg|png|jif)$" )
                    .WithName( "IdCardPhotoFile" )
                    .WithMessage( "يجب رفع صوة من نوع PNG او JPG او JPEG" );
                } );




        }
    }
}
