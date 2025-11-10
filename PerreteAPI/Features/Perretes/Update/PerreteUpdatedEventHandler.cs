using Wolverine;

namespace PerreteAPI.Features.Perretes.Update
{
    public class PerreteUpdatedEventHandler
    {
        private readonly IMessageBus _bus;

        public PerreteUpdatedEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(PerreteUpdatedEvent @event)
        {
            Console.Write($"El perrete '{@event.perrete.Nombre} se ha modificado. :)");
        }
    }
}
