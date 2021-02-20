using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("employee id can not be empty.");
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("customer id can not be empty.");
            RuleFor(p => p.OrderDate).NotEmpty().WithMessage("order date can not be empty.");
            RuleFor(p => p.ShipCity).NotEmpty().WithMessage("ship city can not be empty.");
        }
    }
}
