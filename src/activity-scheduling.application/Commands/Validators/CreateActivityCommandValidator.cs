using activity_scheduling.application.Commands.CreateActivity;
using FluentValidation;

namespace activity_scheduling.application.Commands.Validators
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Informe o nome da atividade")
                .MaximumLength(100).WithMessage("O nome da atividade deve ter no máximo 100 caracteres");

            RuleFor(c => c.StartTime)
                .NotEmpty().WithMessage("Informe o horário de início");

            RuleFor(c => c.EndTime)
                .NotEmpty().WithMessage("Informe o horário de término")
                .GreaterThan(c => c.StartTime).WithMessage("O horário de término deve ser maior que o horário de início");
        }
    }
}
