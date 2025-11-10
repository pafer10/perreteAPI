using FluentValidation;
using Perrete.API.Base.Validators;
using PerreteAPI.Appication.Infrastructure.Repositories;

namespace PerreteAPI.Features.Perretes.Update
{
    public class UpdatePerreteCommandValidator : AbstractValidator<UpdatePerreteCommand>
    {
        public UpdatePerreteCommandValidator(IPerreteRepository perreteRepository) 
        {
            RuleFor(command => command.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.Nombre)
              .NotNull()
              .NotEmpty();

            RuleFor(command => command.Edad)
              .NotNull()
              .NotEmpty();

            RuleFor(command => command.Raza)
              .NotNull()
              .NotEmpty();

            //RuleFor(command => command.Actor)
            //   .NotNull()
            //   .SetValidator(new ActorValidator());
        }
    }
}
