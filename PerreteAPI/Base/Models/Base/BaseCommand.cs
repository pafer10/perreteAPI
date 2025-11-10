using PerreteAPI.Base.Models.Base;

namespace Perrete.API.Base.Models.Base
{
    public class BaseCommand
    {
        public Actor Actor { get; set; }

        public void AddActor(Actor actor)
        {
            Actor = actor;
        }
    }
}
