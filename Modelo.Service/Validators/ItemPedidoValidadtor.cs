using FluentValidation;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Service.Validators
{
    public class ItemPedidoValidator : AbstractValidator<ItemPedido>
    {
        public ItemPedidoValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Objeto não encontrado!");
                });

            RuleFor(c => c.PrecoUnitario)
                .NotEmpty().WithMessage("O campo PrecoUnitario é obrigatorio!")
                .NotNull().WithMessage("O campo PrecoUnitario é obrigatorio!");

            RuleFor(c => c.Quantidade)
                .NotEmpty().WithMessage("O campo Quantidade é obrigatorio!")
                .NotNull().WithMessage("O campo Quantidade é obrigatorio!");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo Descricao é obrigatorio!")
                .NotNull().WithMessage("O campo Descricao é obrigatorio!");
        }
    }
}
