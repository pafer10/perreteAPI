using FluentValidation;
using PerreteAPI.Base.Models.Base;

namespace Perrete.API.Base.Validators
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator() 
        {
            RuleFor(user => user.Id)
                .NotNull()
                .NotEmpty();
            RuleFor(user => user.Nombre)
                .NotNull()
                .NotEmpty();
            RuleFor(user => user.Apellidos)
                .NotNull()
                .NotEmpty();
        }
    }
}
