using Joao.HiringDev.Infraestrutura.Contextos;
using Joao.HiringDev.Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Joao.HiringDev.Testes
{
    public class TesteRepositorioCanalYoutube
    {
        [Theory]
        [InlineData("UCEg3KJRRDYeB5vDNQS28ahg")]
        [InlineData("UCkFhNQh2sme_hf1nltskCgw")]
        [InlineData("UCUjz64h9DUu9LTqE9aZyeuw")]
        public void TesteObterVideo(string id)
        {
            string mySqlConnectionStr = "server=db-hiring-dev.cedjzep1zrvf.us-east-2.rds.amazonaws.com;port=3306;user=admin;password=minhasenha;database=db_hiring_dev";

            var contextOptions = new DbContextOptionsBuilder<Context>()
                                        .UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
                                        .Options;

            var context = new Context(contextOptions);

            var repositorio = new RepositorioCanalYoutube(context);

            var canal = repositorio.ObterCanal(id);
            Assert.Equal(id, canal.Id);
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

            var repositorio = new RepositorioCanalYoutube(context);

            var canais = repositorio.Obter(palavraChave);
            var canaisTestes = canais.Where(x => palavraChave.Contains(x.Title)).ToList();
            Assert.All(canaisTestes, item => Assert.Contains(palavraChave, item.Title));
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

            var repositorio = new RepositorioCanalYoutube(context);
            var canais = repositorio.Obter(palavraChave);
            Assert.Equal(0, canais.Count);
        }
    }
}
