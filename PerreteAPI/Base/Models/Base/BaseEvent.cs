using PerreteAPI.Base.Models.Base;

namespace Perrete.API.Base.Models.Base
{
    public abstract record BaseEvent
    {
        public BaseEvent(Actor user)
        {
            User = user;
            DateTime = DateTime.UtcNow;
        }

        public Actor User { get; set; }
        public DateTime DateTime { get; set; }
    }
}
