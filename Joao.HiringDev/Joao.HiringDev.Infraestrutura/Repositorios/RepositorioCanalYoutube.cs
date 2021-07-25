using Joao.HiringDev.Dominio.Entidades;
using Joao.HiringDev.Infraestrutura.Contextos;
using Joao.HiringDev.Infraestrutura.Core.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Joao.HiringDev.Infraestrutura.Repositorios
{
    public class RepositorioCanalYoutube : Repositorio, IRepositorioCanalYoutube
    {
        private readonly Context _contexto;

        public RepositorioCanalYoutube(Context contexto)
        {
            _contexto = contexto;
        }

        public bool Inserir(CanalYoutube canalYoutube)
        {
            try
            {
                _contexto.CanaisYoutube.Add(canalYoutube);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AddNotification("RepositorioCanalYoutube", ex.Message);
                return false;
            }
        }

        public bool Inserir(List<CanalYoutube> canaisYoutube)
        {
            try
            {
                _contexto.CanaisYoutube.AddRange(canaisYoutube);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AddNotification("RepositorioCanalYoutube", ex.Message);
                return false;
            }
        }

        public List<CanalYoutube> Obter(string palavraChave)
        {
            try
            {
                return _contexto.CanaisYoutube.Where(x => x.Title.Equals(palavraChave) || x.Description.Equals(palavraChave)).ToList();
            }
            catch (Exception ex)
            {
                AddNotification("RepositorioCanalYoutube", ex.Message);
                return new List<CanalYoutube>();
            }
        }

        public CanalYoutube ObterCanal(string id)
        {
            try
            {
                return _contexto.CanaisYoutube.Where(x => x.Id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                AddNotification("RepositorioVideoYoutube", ex.Message);
                return null;
            }
        }
    }
}
