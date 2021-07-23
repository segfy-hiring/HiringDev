using Joao.HiringDev.Dominio.Entidades;
using System.Collections.Generic;

namespace Joao.HiringDev.Infraestrutura.Core.IRepositorios
{
    public interface IRepositorioCanalYoutube : IRepositorio
    {
        bool Inserir(CanalYoutube canalYoutube);
        bool Inserir(List<CanalYoutube> canaisYoutube);
        List<CanalYoutube> Obter(string palavraChave);
    }
}
