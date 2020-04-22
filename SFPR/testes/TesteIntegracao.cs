using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using SearchApi;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace testes
{
    public class TesteIntegracao
    {
        private HttpClient _client;

        public TesteIntegracao()
        {
            var server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET","/v1/search?termo=videos")]
        public async Task BuscaResultadoSucessoAsync(string metodo, string uri)
        {
            //  Arrange
            var request = new HttpRequestMessage(new HttpMethod(metodo), uri);

            //  Act
            var response = await _client.SendAsync(request);

            //  Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET","/v1/search?termo=abasdfiasgasdf")]
        public async Task BuscaResultadoNotFoundAsync(string metodo, string uri)
        {
            //  Arrange
            var request = new HttpRequestMessage(new HttpMethod(metodo), uri);

            //  Act
            var response = await _client.SendAsync(request);

            //  Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
