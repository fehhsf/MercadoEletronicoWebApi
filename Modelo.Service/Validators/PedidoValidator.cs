using FluentValidation;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Service.Validators
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Objeto não encontrado!");
                });

            RuleFor(c => c.NumeroPedido)
                .NotEmpty().WithMessage("O campo NumeroPedido é obrigatorio!")
                .NotNull().WithMessage("O campo NumeroPedido é obrigatorio!");           
        }
    }
}
