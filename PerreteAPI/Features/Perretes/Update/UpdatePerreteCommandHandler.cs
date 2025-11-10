using FluentValidation;
using Perrete.API.Meters;
using PerreteAPI.Appication.Infrastructure.Repositories;
using PerreteAPI.Application.Infrastructure.UnitOfWork;
using PerreteAPI.Features.Perretes.Create;
using Wolverine;
using Wolverine.Persistence;

namespace PerreteAPI.Features.Perretes.Update
{
    public class UpdatePerreteCommandHandler
    {
        private readonly IPerreteRepository _perreteRepository;
        private readonly IValidator<UpdatePerreteCommand> _validator;
        private readonly IMessageBus _bus;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePerreteCommandHandler(IPerreteRepository perreteRepository,
        IValidator<UpdatePerreteCommand> validator,
        IMessageBus bus,
        IUnitOfWork unitOfWork)
        {
            _perreteRepository = perreteRepository;
            _validator = validator;
            _bus = bus;
            _unitOfWork = unitOfWork;
    }
        public async Task Handle(UpdatePerreteCommand command)
        {
            await _validator.ValidateAsync(command);

            var perrete = await _perreteRepository.GetAsync(command.Id);
            perrete.Nombre = command.Nombre;
            perrete.Raza = command.Raza;
            perrete.Edad = command.Edad;

            _perreteRepository.Update(perrete);
            await _unitOfWork.SaveChangesAsync();

            PerreteMeter.Update.Add(1);

            await _bus.PublishAsync(new PerreteUpdatedEvent(command.Actor, perrete));

            await Task.CompletedTask;


        }

    }
}