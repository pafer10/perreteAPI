using FluentValidation;
using Perrete.API.Base.Validators;

namespace PerreteAPI.Features.Perretes.Create
{
    public class CreatePerreteCommandValidator : AbstractValidator<CreatePerreteCommand>
    {
        public CreatePerreteCommandValidator() 
        {
            RuleFor(command => command.Nombre)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.Edad)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.Raza)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.Actor)
                .NotNull()
                .SetValidator(new ActorValidator());
        }
    }
}
