namespace Joao.HiringDev.Dominio.Entidades
{
    public class CanalYoutube
    {
        public string ID { get; private set; }
        public string Titulo { get; private set; }

        public CanalYoutube(string iD, string titulo)
        {
            ID = iD;
            Titulo = titulo;
        }

        private CanalYoutube()
        {
        }
    }
}
