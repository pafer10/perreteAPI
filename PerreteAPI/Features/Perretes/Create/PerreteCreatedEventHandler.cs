using PerreteAPI.Application.Infrastructure.UnitOfWork;

namespace PerreteAPI.Features.Perretes.Create
{
    public class PerreteCreatedEventHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public PerreteCreatedEventHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task Handle(PerreteCreatedEvent @event)
        {
            Console.Write($"El perrete '{@event.perrete.Nombre} se ha añadido. :)");

            //await _unitOfWork.SaveAsync();
        }
    }
}
