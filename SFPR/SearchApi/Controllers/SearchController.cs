using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchApi.Data;
using SearchApi.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;


namespace SearchApi.Controllers
{
    [ApiController]
    [Route("v1/search")]
    public class VideoController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<Busca>> Get([FromServices] DataContext context, string termo)
        {
            if(string.IsNullOrEmpty(termo))
            {
                return BadRequest(termo);
            }
            var novaBusca = new Busca();

            //var buscaDB = await context.Buscas
            //                           .AsNoTracking()
            //                           .FirstOrDefaultAsync();

            YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "replace_value"
            });

            SearchResource.ListRequest listRequest = youtube.Search.List("snippet");
            listRequest.Q = termo;

            listRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;

            SearchListResponse searchResponse = await listRequest.ExecuteAsync();

            foreach (SearchResult searchResult in searchResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        novaBusca.Videos.Add(new BuscaVideo
                        {
                            Id = searchResult.Id.VideoId,
                            Title = searchResult.Snippet.Title,
                            Description = searchResult.Snippet.Description
                        });
                        break;

                    case "youtube#channel":
                        novaBusca.Channels.Add(new BuscaChannel
                        {
                            Id = searchResult.Id.ChannelId,
                            Title = searchResult.Snippet.Title,
                            Description = searchResult.Snippet.Description
                        });
                        break;

                    default:
                        break;
                }
            }

            if (novaBusca.IsEmpty())
            {
                return NotFound(termo);
            }
            return Ok(novaBusca);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Busca>> Post(
            [FromServices] DataContext context,
            [FromBody] Busca model)
        {
            if (ModelState.IsValid)
            {
                context.Buscas.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
    }
}