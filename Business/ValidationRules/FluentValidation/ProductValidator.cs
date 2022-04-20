using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product name cannot be empty");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Description cannot be empty"); ;
            RuleFor(p => p.Name).MaximumLength(100);
            RuleFor(p => p.Description).MaximumLength(500);
            RuleFor(p => p.BuyPrice).NotEmpty();

        }
    }
}
