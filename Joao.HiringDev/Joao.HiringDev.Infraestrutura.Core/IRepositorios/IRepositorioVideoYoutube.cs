using Joao.HiringDev.Dominio.Entidades;
using System.Collections.Generic;

namespace Joao.HiringDev.Infraestrutura.Core.IRepositorios
{
    public interface IRepositorioVideoYoutube : IRepositorio
    {
        bool Inserir(VideoYoutube videoYoutube);
        bool Inserir(List<VideoYoutube> videosYoutube);
        List<VideoYoutube> Obter(string palavraChave);
    }
}
