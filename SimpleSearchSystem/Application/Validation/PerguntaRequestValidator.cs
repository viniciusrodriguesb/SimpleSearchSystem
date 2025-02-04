using Application.DTO.Request;
using FluentValidation;

namespace Application.Validation
{
    public class PerguntaRequestValidator : AbstractValidator<PerguntaRequest>
    {

        public PerguntaRequestValidator()
        {
            RuleFor(x => x.FormularioId)
               .GreaterThan(0).WithMessage("O ID do formulário deve ser maior que zero.")
               .NotEmpty().WithMessage("O ID do formulário é obrigatório.");

            RuleFor(x => x.Pergunta)
                .NotEmpty().WithMessage("O texto da pergunta é obrigatório.")
                .Length(10, 200).WithMessage("A pergunta deve ter entre 10 e 200 caracteres.");

            RuleFor(x => x.OpcoesRespostas)
               .Must(opcoes => opcoes != null && opcoes.Count >= 2 && opcoes.Count <= 4).WithMessage("A lista de opções deve conter entre 2 e 4 elementos.")
               .NotNull().WithMessage("Para gerar uma pergunta é preciso inserir suas opções.")
               .NotEmpty().WithMessage("Para gerar uma pergunta é preciso inserir suas opções.");
        }

    }

    public class EditPerguntaRequestValidator : AbstractValidator<EditPerguntaRequest>
    {

        public EditPerguntaRequestValidator()
        {
            RuleFor(x => x.IdPergunta)
               .GreaterThan(0).WithMessage("O ID da pergunta deve ser maior que zero.")
               .NotEmpty().WithMessage("O ID da pergunta é obrigatório.");

            RuleFor(x => x.NovoTexto)
                .Length(10, 200).WithMessage("A pergunta deve ter entre 10 e 200 caracteres.")
                .When(x => x.NovoTexto != null);

            RuleFor(x => x.NovaOrdem)
               .GreaterThan(0).WithMessage("A ordem da pergunta deve ser maior que zero.")
               .When(x => x.NovaOrdem != null);

        }

    }

}
