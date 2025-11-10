using Perrete.API.Features.Perretes.Responses;
using PerreteAPI.Appication.Infrastructure.Repositories;

namespace Perrete.API.Features.Perretes.Get.GetAll
{
    public class GetAllPerretesQueryHandler
    {
        private readonly IPerreteRepository _perreteRepository;

        public GetAllPerretesQueryHandler(IPerreteRepository perreteRepository)
        {
            _perreteRepository = perreteRepository;
        }

        public async Task<IEnumerable<PerreteResponse>> Handle(GetAllPerretesQuery query)
        {
            var perretes = await _perreteRepository.GetAllAsync();

            return perretes.Select(p => new PerreteResponse
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Raza = p.Raza,
                Edad = p.Edad
            });
        }
    }
}
