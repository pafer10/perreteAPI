namespace PerreteAPI.Domain
{
    public class Perrete : Base
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Raza { get; set; }

    //para entity framework
    public Perrete() { }

        public Perrete(string nombre, string raza, int edad)
        {
            Nombre = nombre;
            Raza = raza;
            Edad = edad;
        }
    }
}
