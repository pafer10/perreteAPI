using Perrete.API.Base.Models.Base;

namespace PerreteAPI.Features.Perretes.Update
{
    public class UpdatePerreteCommand : BaseCommand
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public string Raza { get; set; }
    }
}
