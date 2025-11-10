namespace PerreteAPI.Base.Models.Responses
{
    public class EntityCreatedResponse
        //id que devuelve en la petición de crear como OK.
    {
        public EntityCreatedResponse(Guid id) {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
