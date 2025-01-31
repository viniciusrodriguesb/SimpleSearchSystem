using Application.DTO.Request;
using FluentValidation;

namespace Application.Validation
{
    public class FormularioRequestValidator : AbstractValidator<FormularioRequest>
    {
        public FormularioRequestValidator()
        {
            RuleFor(x => x.UsuarioId)
                .GreaterThan(0).WithMessage("O ID do usuário deve ser maior que zero.")
                .NotEmpty().WithMessage("O ID do usuário é obrigatório.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .Length(10, 200).WithMessage("A descrição deve ter entre 10 e 200 caracteres.");
        }
    }

    public class EditFormularioValidator : AbstractValidator<EditFormularioRequest>
    {
        public EditFormularioValidator()
        {
            RuleFor(x => x.IdFormulario)
               .GreaterThan(0).WithMessage("O ID do usuário deve ser maior que zero.")
               .NotEmpty().WithMessage("O ID do usuário é obrigatório.");

            RuleFor(x => x.NovaDescricao)
                .Length(10, 200).WithMessage("A descrição deve ter entre 10 e 200 caracteres.")
                .When(x => x.NovaDescricao != null);

            RuleFor(x => x.IcAtivo)
                .Must(value => value == true || value == false).WithMessage("O campo 'Ativo' deve ser um valor booleano válido.")
                .When(x => x.IcAtivo.HasValue);
        }
    }

}
