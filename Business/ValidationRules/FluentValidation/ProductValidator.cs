using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("ürün ismi boş olamaz");
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty()/*.WithMessage("fiyat boş olamaz")*/;
            RuleFor(p => p.UnitPrice).GreaterThan(0)/*.*//*WithMessage("fiyat 0 dan büyük olmalıdır.")*/;
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId > 0);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("ürün isinleri A harfi ile başlamalıdır.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
