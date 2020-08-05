using API.Template.Default.Business.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Template.Default.Business.Validations
{
    public class ProdutoValidation : AbstractValidator<Product>
    {
        public ProdutoValidation()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio.")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
