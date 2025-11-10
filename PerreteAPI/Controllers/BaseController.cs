using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PerreteAPI.Base.Models.Base;

namespace PerreteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //quien ejecutará las acciones de los métodos http del controlador
    public class BaseController : Controller
    {
        internal Actor Actor { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            Actor = new Actor()
            {
                Id = Guid.Parse("FBE6880C-93B5-4138-A388-DBD9D09609E2"),
                Nombre = "Paula",
                Apellidos = "Fernandez",
            };
        }
    }
}
