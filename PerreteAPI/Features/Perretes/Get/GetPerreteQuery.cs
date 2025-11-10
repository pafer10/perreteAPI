using Perrete.API.Base.Models.Base;

namespace PerreteAPI.Features.Perretes.Get
{
    public class GetPerreteQuery : BaseQuery
    {
        public GetPerreteQuery(Guid id) {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
