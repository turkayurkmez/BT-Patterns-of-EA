using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Commands.CreateNewProduct
{
    public class CreateNewProductCommandValidator : AbstractValidator<CreateNewProductCommand>
    {
        public CreateNewProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Ürün adı gereklidir")
                .MaximumLength(100).WithMessage("İsim en çok 100 karakter olmalıdır");

            RuleFor(p => p.SKU).NotEmpty()
                               .WithMessage("SKU gereklidir")
                               .MaximumLength(70).WithMessage("SKU en çok 70 karakter olmalıdır");

            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama gereklidir")
                                       .MaximumLength(500).WithMessage("Açıklama en çok 500 karakter olmalıdır");

            RuleFor(p => p.Price).NotNull().WithMessage("Fiyat gereklidir");

            RuleFor(p => p.StockQuantity).GreaterThanOrEqualTo(0).WithMessage("Stok miktarı 0'dan büyük olmalıdır");


        }
    }
}
