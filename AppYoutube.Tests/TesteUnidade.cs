using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AppYoutube.Tests
{
    [TestClass]
    public class TesteUnidade
    {
        [TestMethod]
        public void Caso_a_pesquisa_tenha_itens()
        {
            var result = new List<string>();
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Caso_a_pesquisa_nao_tenha_itens()
        {
            var result = new List<string>();
            Assert.AreEqual(0, result.Count);
        }
    }
}
