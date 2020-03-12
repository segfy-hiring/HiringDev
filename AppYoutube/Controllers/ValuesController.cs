using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppYoutube.Models;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppYoutube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataService _dataService;

        public ValuesController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<SearchResult>> Get(string word)
        {
            var retorno = new Development();
            var lista = retorno.DadosYoutTube(word);
            var novaLista = new List<SearchResult>();
            foreach (var item in lista)
            {
                var novoObjeto = new Dados { Description = item.Snippet.Description, Name = item.Snippet.ChannelTitle, URL = item.Snippet.ChannelId };
                _dataService.Create(novoObjeto);
                novaLista.Add(item);
            }
            //return retorno.DadosYoutTube(word);
            return novaLista;
        }

        [HttpPost]
        public ActionResult<Dados> Create(Dados dados)
        {
            _dataService.Create(dados);

            return CreatedAtRoute("Get", new { id = dados.Id.ToString() }, dados);
        }

        [Route("searchdata")]
        [HttpGet]
        public ActionResult<List<Dados>> SearchData() =>
            _dataService.Get();
    }
}
