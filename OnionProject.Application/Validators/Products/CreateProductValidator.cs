using System.Data;
using FluentValidation;
using OnionProject.Application.ViewModels;

namespace OnionProject.Application.Validators.Products;

public class CreateProductValidator : AbstractValidator<VM_Create_Product>
{
    public CreateProductValidator()
    {
        RuleFor(C => C.Name).NotEmpty().NotNull().WithMessage("İsmi boş girmeyiniz.").MaximumLength(150)
            .MinimumLength(2).WithMessage("Ürün adı 2 ile 150 karakter arasında olmalıdır.");
        
        RuleFor(s=>s.Stock).NotEmpty().NotNull().WithMessage("Stoku boş girmeyiniz.").Must(s=>s>=0).WithMessage(
            "Stok sayısı negatif olamaz.");
        RuleFor(p=>p.Price).NotEmpty().NotNull().WithMessage("Fiyatı boş girmeyiniz.").Must(s=>s>0).WithMessage(
            "Fiyat sıfırdan büyük olmalıdır.");
    }
}