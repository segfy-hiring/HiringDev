using Joao.HiringDev.Dominio.Core.Interfaces;

namespace Joao.HiringDev.Dominio.Entidades
{
    public class VideoYoutube : IEntidade
    {
        private VideoYoutube()
        {
        }

        public string ID { get; private set; }
        public string Titulo { get; private set; }

        public VideoYoutube(string iD, string titulo)
        {
            ID = iD;
            Titulo = titulo;
        }
    }
}
