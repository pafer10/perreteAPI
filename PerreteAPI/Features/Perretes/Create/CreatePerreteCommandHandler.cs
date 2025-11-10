using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Perrete.API.Meters;
using PerreteAPI.Appication.Infrastructure.Repositories;
using PerreteAPI.Application.Infrastructure.UnitOfWork;
using PerreteAPI.Base.Models.Responses;
using Wolverine;
using PerreteAPI.Domain;

namespace PerreteAPI.Features.Perretes.Create
{
    public class CreatePerreteCommandHandler
    {
        private readonly IPerreteRepository _perreteRepository;
        private readonly IValidator<CreatePerreteCommand> _validator;
        private readonly IMessageBus _bus;
        private readonly IUnitOfWork _unitOfWork;
    

    public CreatePerreteCommandHandler(
        IPerreteRepository perreteRepository,
        IValidator<CreatePerreteCommand> validator,
        IMessageBus bus,
        IUnitOfWork unitOfWork)
        {
            _perreteRepository = perreteRepository;
            _validator = validator;
            _bus = bus;
            _unitOfWork = unitOfWork;
        }

        public async Task<EntityCreatedResponse> Handle(CreatePerreteCommand command)
        {
            await _validator.ValidateAndThrowAsync(command);

            var perrete = new Domain.Perrete(command.Nombre, command.Raza, command.Edad);

            await _perreteRepository.AddAsync(perrete);
            await _unitOfWork.SaveChangesAsync();

            PerreteMeter.Create.Add(1); //cuenta las veces que se ejecuta en la app 

            await _bus.PublishAsync(new PerreteCreatedEvent(command.Actor, perrete));

            return new EntityCreatedResponse(perrete.Id);

        }
    }

}