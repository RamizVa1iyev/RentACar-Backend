using System;
using FluentValidation;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.ReturnDate).NotNull();
            RuleFor(r => r.RentDate).LessThan(DateTime.Now);
            RuleFor(r => r.ReturnDate).LessThan(DateTime.Now);
            RuleFor(r => r.RentDate).LessThan(r => r.ReturnDate).When(r => r.ReturnDate != null);
        }
    }
}
