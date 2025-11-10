using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Perrete.API.Features.Perretes.Get.GetAll;
using Perrete.API.Features.Perretes.Responses;
using PerreteAPI.Base.Models.Responses;
using PerreteAPI.Features.Perretes.Create;
using PerreteAPI.Features.Perretes.Get;
using PerreteAPI.Features.Perretes.Update;
using Wolverine;

namespace PerreteAPI.Controllers
{
    [Route("perretes")]
    [ApiController]
    public class PerreteController : BaseController
    {
        private readonly IMessageBus _bus;
        private readonly ILogger<PerreteController> _logger;

        public PerreteController(IMessageBus bus, ILoggerFactory loggerFactory)
        {
            _bus = bus;
            _logger = loggerFactory.CreateLogger<PerreteController>();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreatePerreteAsync([FromBody]CreatePerreteCommand command)
        {
            command.Actor = base.Actor; //calcula  el verdadero user a través de jwt in

            var response = await _bus.InvokeAsync<EntityCreatedResponse>(command);

            return Ok(response);

            //return new CreatedResult($"perretes/{response.Id}", response.Id);
        }

        //Este se hace con query puesto que no modifica solo lee
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPerreteAsync([FromRoute] Guid id)
        {
            var query = new GetPerreteQuery(id);
            {
                Actor = base.Actor;
            };

            var response = await _bus.InvokeAsync<PerreteResponse>(query);

            return new OkObjectResult(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePerreteAsync([FromRoute] Guid id, UpdatePerreteCommand command)
        {
            //command.actor = base.actor;

            await _bus.InvokeAsync(command);

            return new AcceptedResult();
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAllPerretesAsync()
        {
            var query = new GetAllPerretesQuery();
           

            var response = await _bus.InvokeAsync<IEnumerable<PerreteResponse>>(query);
            return Ok(response);
        }

    }
}

