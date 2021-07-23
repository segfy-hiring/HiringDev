using Joao.HiringDev.Dominio.Entidades;
using Joao.HiringDev.Infraestrutura.Contextos;
using Joao.HiringDev.Infraestrutura.Core.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Joao.HiringDev.Infraestrutura.Repositorios
{
    public class RepositorioVideoYoutube : Repositorio, IRepositorioVideoYoutube
    {
        private readonly Context _contexto;

        public RepositorioVideoYoutube(Context contexto)
        {
            _contexto = contexto;
        }

        public bool Inserir(VideoYoutube videoYoutube)
        {
            try
            {
                _contexto.VideosYoutube.Add(videoYoutube);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AddNotification("RepositorioVideoYoutube", ex.Message);
                return false;
            }
        }

        public bool Inserir(List<VideoYoutube> videosYoutube)
        {
            try
            {
                _contexto.VideosYoutube.AddRange(videosYoutube);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                AddNotification("RepositorioVideoYoutube", ex.Message);
                return false;
            }
        }

        public List<VideoYoutube> Obter(string palavraChave)
        {
            try
            {
                return _contexto.VideosYoutube.Where(x => x.Title.Equals(palavraChave) || x.Description.Equals(palavraChave)).ToList();
            }
            catch(Exception ex)
            {
                AddNotification("RepositorioVideoYoutube", ex.Message);
                return new List<VideoYoutube>();
            }
        }
    }
}
