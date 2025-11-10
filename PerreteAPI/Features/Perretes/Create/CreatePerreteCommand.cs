using Perrete.API.Base.Models.Base;

namespace PerreteAPI.Features.Perretes.Create
{
    public class CreatePerreteCommand : BaseCommand
    {
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public string Raza { get; set; }
    }
}
