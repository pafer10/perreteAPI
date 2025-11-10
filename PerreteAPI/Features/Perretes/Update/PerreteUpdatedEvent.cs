using Perrete.API.Base.Models.Base;
using PerreteAPI.Base.Models.Base;
using PerreteAPI.Domain;

namespace PerreteAPI.Features.Perretes.Update
{//record = inmutable, no puedes modificar el valor de esas propiedades
    public record PerreteUpdatedEvent(Actor actor, PerreteAPI.Domain.Perrete perrete) : BaseEvent(actor);

}
