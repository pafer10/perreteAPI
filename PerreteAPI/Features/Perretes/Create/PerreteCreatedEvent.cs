using Perrete.API.Base.Models.Base;
using PerreteAPI.Base.Models.Base;
using PerreteAPI.Domain;

namespace PerreteAPI.Features.Perretes.Create
{
    public record PerreteCreatedEvent(Actor actor, PerreteAPI.Domain.Perrete perrete) : BaseEvent(actor);
    
}
