using FluentValidation;
using Perrete.API.Features.Perretes.Responses;
using Perrete.API.Meters;
using PerreteAPI.Appication.Infrastructure.Repositories;

namespace PerreteAPI.Features.Perretes.Get
{
    public class GetPerreteQueryHandler
    {
        private readonly IPerreteRepository _perreteRepository;
        private readonly IValidator<GetPerreteQuery> _validator;

        public GetPerreteQueryHandler(IPerreteRepository perreteRepository, IValidator<GetPerreteQuery> validator)
        {
            _perreteRepository = perreteRepository;
            _validator = validator;
        }

        public async Task<PerreteResponse> Handle(GetPerreteQuery query)
        {
            await _validator.ValidateAndThrowAsync(query);

            var perrete = await _perreteRepository.GetAsync(query.Id);

            var response = new PerreteResponse()
            {
                Id = perrete.Id,
                Nombre = perrete.Nombre,
                Raza = perrete.Raza,
                Edad = perrete.Edad
            };

            PerreteMeter.Read.Add(1);

            return response;
        }
    }
}
