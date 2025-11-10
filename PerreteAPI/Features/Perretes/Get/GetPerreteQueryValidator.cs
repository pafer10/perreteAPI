using FluentValidation;
using Perrete.API.Base.Validators;

namespace PerreteAPI.Features.Perretes.Get
{
    public class GetPerreteQueryValidator : AbstractValidator<GetPerreteQuery>
    {
        public GetPerreteQueryValidator() 
        {
            RuleFor(query => query.Id)
                    .NotNull()
                    .NotEmpty();

            //RuleFor(query => query.Actor)
            //    .NotNull()
            //    .SetValidator(new ActorValidator());
        }
    }
}
