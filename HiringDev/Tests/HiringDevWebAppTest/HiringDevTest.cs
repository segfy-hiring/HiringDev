using Xunit;
using FluentAssertions;
using System.Net;

namespace HiringDevWebAppTest
{
    public class HiringDevTest
    {
        private readonly TestContext _testContext;


        public HiringDevTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async System.Threading.Tasks.Task TesteRetornoOk()
        {

            var response = await _testContext.Client.GetAsync("/api/YouTube/PesquisarCanais?texto=$gugu&pagina=$1&quantidade=$1");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
