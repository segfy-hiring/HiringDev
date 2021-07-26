using Joao.HiringDev.Infraestrutura.Contextos;
using Joao.HiringDev.Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using Xunit;

namespace Joao.HiringDev.Testes
{
    public class TesteRepositorioVideoYoutube
    {      
        [Theory]
        [InlineData("_uF0FmkAlzo")]
        [InlineData("ATMmwfzEiM4")]
        [InlineData("FqR3bpyTiis")]
        public void TesteObterVideo(string id)
        {
            string mySqlConnectionStr = "server=db-hiring-dev.cedjzep1zrvf.us-east-2.rds.amazonaws.com;port=3306;user=admin;password=minhasenha;database=db_hiring_dev";
            
            var contextOptions = new DbContextOptionsBuilder<Context>()
                                        .UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
                                        .Options;

            var context = new Context(contextOptions);

            var repositorio = new RepositorioVideoYoutube(context);

            var video = repositorio.ObterVideo(id);
            Assert.Equal(id, video.Id);
        }

        [Theory]
        [InlineData("joão carias")]
        [InlineData("carias")]
        public void TesteObter(string palavraChave)
        {
            string mySqlConnectionStr = "server=db-hiring-dev.cedjzep1zrvf.us-east-2.rds.amazonaws.com;port=3306;user=admin;password=minhasenha;database=db_hiring_dev";

            var contextOptions = new DbContextOptionsBuilder<Context>()
                                        .UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
                                        .Options;

            var context = new Context(contextOptions);

            var repositorio = new RepositorioVideoYoutube(context);

            var videos = repositorio.Obter(palavraChave);
            var videosTestes = videos.Where(x => palavraChave.Contains(x.Title)).ToList();
            Assert.All(videosTestes, item => Assert.Contains(palavraChave, item.Title));
        }

        [Theory]
        [InlineData("naovaiencontraressapalavraisasdfasdfalksdfjalskdfjasdfasldfjasldfk")]
        [InlineData("naovaiencontraressapalavraisasdfasdfalksdfjalskdfjasdfasldfjasldfkasdf")]
        public void TesteObterNaoEncontrado(string palavraChave)
        {
            string mySqlConnectionStr = "server=db-hiring-dev.cedjzep1zrvf.us-east-2.rds.amazonaws.com;port=3306;user=admin;password=minhasenha;database=db_hiring_dev";

            var contextOptions = new DbContextOptionsBuilder<Context>()
                                        .UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
                                        .Options;

            var context = new Context(contextOptions);

            var repositorio = new RepositorioVideoYoutube(context);
            var video = repositorio.Obter(palavraChave);
            Assert.Equal(0, video.Count);
        }
    }
}
