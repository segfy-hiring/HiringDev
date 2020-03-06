using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using appcore.Models;
using appcore.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using appcore.Models.Result;

namespace appcore.Controllers 
    {
    
    [ApiController]
    [Route("api/[controller]")]
    public class YoutubeController : ControllerBase 
    {

        private readonly YoutubeService _ytService;

        public YoutubeController(YoutubeService ytService)
        {
            _ytService = ytService;
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        public ActionResult<List<YoutubeModel>> Get() =>
            _ytService.Get();

        [HttpGet("{query}")]
        public Task<YTResult> Get(string query)
        {
            var yt = _ytService.Search(query);

            return yt;
        }

        //[HttpPost]
        //public ActionResult<YoutubeModel> Create(YoutubeModel yt)
        //{
        //    _ytService.Create(yt);

        //    return CreatedAtRoute("Getyt", new { id = yt._id.ToString() }, yt);
        //}

  


    }
}