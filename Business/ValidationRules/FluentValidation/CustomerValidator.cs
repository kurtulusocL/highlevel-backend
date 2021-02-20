using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.ContactName).NotEmpty().WithMessage("product name can not be empty.");
            RuleFor(p => p.CompanyName).NotEmpty().WithMessage("company name can not be empty.");
            RuleFor(p => p.City).NotEmpty().WithMessage("city can not be empty.");
        }
    }
}
